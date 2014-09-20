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

namespace AltaNetTestServer
{
	public partial class Server : Form
	{
		//private TcpServerHandler serverHandler;
		private AltaNetTest.ServerManager serverHandler;

		public Server()
		{
			InitializeComponent();
			serverHandler = new AltaNetTest.ServerManager(IPAddress.Any, 7878);
			serverHandler.OnClientConnected += serverHandler_ClientConnected;
			serverHandler.OnClientDisonnected += serverHandler_ClientDisonnected;
			serverHandler.OnMessageReceived += serverHandler_OnMessageReceived;
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
			if (serverHandler.IsRunning)
			{
				WriteInConsole("Server is already running!");
				return;
			}

			btnStart.Enabled = false;
			txtIp.Enabled = false;
			txtPort.Enabled = false;

			serverHandler.Ip = IPAddress.Parse(txtIp.Text);
			serverHandler.Port = int.Parse(txtPort.Text);
			
			serverHandler.Start();

			btnStop.Enabled = true;
			btnSendAll.Enabled = true;
			btnSendFirst.Enabled = true;
			WriteInConsole("Server is now listenning to " + serverHandler.Ip + ":" + serverHandler.Port);
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			if (!serverHandler.IsRunning)
			{
				WriteInConsole("Server is already stopped!");
				return;
			}
			btnStop.Enabled = false;
			btnSendAll.Enabled = false;
			btnSendFirst.Enabled = false;

			serverHandler.Stop();

			btnStart.Enabled = true;
			txtIp.Enabled = true;
			txtPort.Enabled = true;

			WriteInConsole("Server is stopped");
		}

		#region OnClientConnect

		void serverHandler_ClientConnected(object sender, TcpEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnClientConnect(e);
				});
			}
			else
			{
				OnClientConnect(e);
			}
		}

		private void OnClientConnect(TcpEventArgs arg)
		{
			WriteInConsole("Client connected");
		}

		#endregion

		void serverHandler_ClientDisonnected(object sender, TcpEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnClientDisconnect(e);
				});
			}
			else
			{
				OnClientDisconnect(e);
			}
		}

		private void OnClientDisconnect(TcpEventArgs arg)
		{
			WriteInConsole("Client disconnected");
		}

		void serverHandler_OnMessageReceived(object sender, TcpReceivedEventArgs e)
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

		private void OnMessageReceived(TcpReceivedEventArgs e)
		{
			WriteInConsole("New message: " + Encoding.UTF8.GetString(e.Data));
		}

		private void btnSendAll_Click(object sender, EventArgs e)
		{
			serverHandler.SendToAll("BROADCAST: Everyone should receive this message");
		}

		private void btnSendFirst_Click(object sender, EventArgs e)
		{
			if (serverHandler.ConnectedClients == null || serverHandler.ConnectedClients.Count == 0)
				return;

			TcpClientInfo firstClient = serverHandler.ConnectedClients[0];
			serverHandler.SendTo(firstClient, "Testing testing 1-2");
		}
	}
}
