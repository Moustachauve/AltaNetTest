using System;
using System.Windows.Forms;
using AltarNet;
using System.Net;
using AltaNetTest;

namespace AltaNetTestClient
{
	public partial class Client : Form
	{
		private ClientManager m_clientHandler;

		public Client()
		{
			InitializeComponent();
			m_clientHandler = new ClientManager(IPAddress.Any, 7878);
			m_clientHandler.OnDisconnected += clientHandler_Disconnected;
			m_clientHandler.OnMessageReceived += clientHandler_OnMessageReceived;
			m_clientHandler.OnLogingFeedback += m_clientHandler_OnLogingFeedback;
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
			if (m_clientHandler.IsConnected)
			{
				WriteInConsole("You are already connected to a server.");
				return;
			}

			btnStart.Enabled = false;
			txtIp.Enabled = false;
			txtPort.Enabled = false;

			m_clientHandler.Ip = IPAddress.Parse(txtIp.Text);
			m_clientHandler.Port = int.Parse(txtPort.Text);

			if (m_clientHandler.Connect())
			{
				btnStop.Enabled = true;
				btnSend.Enabled = true;
				btnLogin.Enabled = true;
				WriteInConsole("You are now connected to " + m_clientHandler.Ip + ":" + m_clientHandler.Port);
			}
			else
			{
				btnStart.Enabled = true;
				txtIp.Enabled = true;
				txtPort.Enabled = true;

				WriteInConsole("Could not connect to " + m_clientHandler.Ip + ":" + m_clientHandler.Port + ": " + m_clientHandler.LastConnectionError.Message);
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
			WriteInConsole("Connection to " + m_clientHandler.Ip + ":" + m_clientHandler.Port + " has been lost.");

			btnStart.Enabled = true;
			txtIp.Enabled = true;
			txtPort.Enabled = true;

			btnStop.Enabled = false;
			btnSend.Enabled = false;
			btnLogin.Enabled = false;
		}

		void m_clientHandler_OnLogingFeedback(object sender, LoginFeedbackArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke((MethodInvoker)delegate
				{
					OnLoggingFeedback(e);
				});
			}
			else
			{
				OnLoggingFeedback(e);
			}
		}

		private void OnLoggingFeedback(LoginFeedbackArgs e)
		{
			btnLogin.Enabled = !e.Succeeded;

			if (e.Succeeded)
				WriteInConsole("Logged in!");
			else
				WriteInConsole("Error: Bad username/password combination");
		}

		void clientHandler_OnMessageReceived(object sender, NotificationReceivedArgs e)
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

        private void OnMessageReceived(NotificationReceivedArgs args)
		{
			WriteInConsole(args.Type + args.Message);
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			m_clientHandler.SendMessage();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			m_clientHandler.Disconnect();
			btnStart.Enabled = true;
			txtIp.Enabled = true;
			txtPort.Enabled = true;

			btnStop.Enabled = false;
			btnSend.Enabled = false;
			btnLogin.Enabled = false;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			m_clientHandler.SendLogin("test", "test");
		}
	}
}
