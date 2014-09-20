using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltarNet;
using System.Net;
using AltaNetTest;

namespace AltaNetTestClient
{
	public partial class Client : Form
	{
		delegate void WriteInConsoleCallback(string text);
		delegate void UpdateUICallback(bool state);

		private ClientManager clientHandler;

		public Client()
		{
			InitializeComponent();
			clientHandler = new ClientManager(IPAddress.Any, 7878);
			clientHandler.OnDisconnected += clientHandler_Disconnected;
			clientHandler.OnMessageReceived += clientHandler_OnMessageReceived;
		}

		private void WriteInConsole(string text)
		{
			if (txtLog.Text.Length == 0)
				txtLog.Text = text;
			else
				txtLog.AppendText("\r\n" + text);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (clientHandler.IsConnected)
			{
				WriteInConsole("You are already connected to a server.");
				return;
			}

			btnStart.Enabled = false;
			txtIp.Enabled = false;
			txtPort.Enabled = false;

			clientHandler.Ip = IPAddress.Parse(txtIp.Text);
			clientHandler.Port = int.Parse(txtPort.Text);

			if (clientHandler.Connect())
			{
				btnStop.Enabled = true;
				btnSend.Enabled = true;
				WriteInConsole("You are now connected to " + clientHandler.Ip + ":" + clientHandler.Port);
			}
			else
			{
				btnStart.Enabled = true;
				txtIp.Enabled = true;
				txtPort.Enabled = true;

				WriteInConsole("Could not connect to " + clientHandler.Ip + ":" + clientHandler.Port + ": " + clientHandler.LastConnectionError.Message);
			}
		}

		void clientHandler_Disconnected(object sender, TcpEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnDisconnected(e);
				});
			}
			else
			{
				OnDisconnected(e);
			}
		}

		private void OnDisconnected(TcpEventArgs args)
		{
			WriteInConsole("Connection to " + clientHandler.Ip + ":" + clientHandler.Port + " has been lost.");

			btnStart.Enabled = true;
			txtIp.Enabled = true;
			txtPort.Enabled = true;

			btnStop.Enabled = false;
			btnSend.Enabled = false;
		}

		void clientHandler_OnMessageReceived(object sender, TcpReceivedEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnMessageReceived(e);
				});
			}
			else
			{
				OnMessageReceived(e);
			}
		}

		private void OnMessageReceived(TcpReceivedEventArgs args)
		{
			WriteInConsole("New message: " + Encoding.UTF8.GetString(args.Data));
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			clientHandler.SendMessage();
		}
	}
}
