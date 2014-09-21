using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using AltarNet;

namespace AltaNetTest
{
	public class ServerManager
	{
		#region Event definitions

		public event EventHandler<TcpEventArgs> OnClientConnected;
		public event EventHandler<TcpEventArgs> OnClientDisonnected;
		public event EventHandler<TcpReceivedEventArgs> OnMessageReceived;

		#endregion

		#region Attributes

		private TcpServerHandler m_server;
		private IPAddress m_ip;
		private int m_port;

		private List<TcpClientInfo> m_clientList;

		#endregion

		#region Properties

		public IPAddress Ip
		{
			get { return m_ip; }
			set { m_ip = value; }
		}

		public int Port
		{
			get { return m_port; }
			set { m_port = value; }
		}

		public bool IsRunning
		{
			get { return m_server != null; }
		}

		public List<TcpClientInfo> ConnectedClients
		{
			get { return m_clientList; }
		}

		#endregion

		#region Constructor

		public ServerManager(IPAddress pIp, int pPort)
		{
			m_ip = pIp;
			m_port = pPort;
		}

		~ServerManager()
		{
			Stop();
		}

		#endregion

		#region Start / Stop

		public void Start()
		{
			if (IsRunning)
				return;
			m_server = new TcpServerHandler(m_ip, m_port);
			m_server.Connected += m_server_Connected;
			m_server.Disconnected += m_server_Disconnected;
			m_server.ReceivedFull += m_server_ReceivedFull;
			m_server.Start();
		}

		public void Stop()
		{
			if (!IsRunning)
				return;
			m_server.DisconnectAll();
			m_server.Stop();
		}

		#endregion

		#region Event listeners

		#region OnClientConnect

		void m_server_Connected(object sender, TcpEventArgs e)
		{
			if (OnClientConnected != null)
			{
				OnClientConnected(this, e);
			}
		}

		#endregion

		#region OnCliendDisconnect

		void m_server_Disconnected(object sender, TcpEventArgs e)
		{
			if (OnClientDisonnected != null)
			{
				OnClientDisonnected(this, e);
			}
		}

		#endregion

		#region OnMessageReceive

		void m_server_ReceivedFull(object sender, TcpReceivedEventArgs e)
		{
			if (OnMessageReceived != null)
			{
				OnMessageReceived(this, e);
			}
		}

		#endregion

		#endregion

		public void SendToAll(string pMessage)
		{
			byte[] data = Encoding.UTF8.GetBytes(pMessage);
			m_server.SendAll(data);
		}

		public void SendTo(TcpClientInfo pClient, string pMessage)
		{
			byte[] data = Encoding.UTF8.GetBytes(pMessage);
			m_server.Send(pClient, data);
		}

	}
}
