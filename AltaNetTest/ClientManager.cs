using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using AltarNet;

namespace AltaNetTest
{
	public class ClientManager
	{
		#region Event definitions

		public event EventHandler<TcpEventArgs> OnDisconnected;
		public event EventHandler<TcpReceivedEventArgs> OnMessageReceived;

		#endregion

		#region Attributes

		private TcpClientHandler m_client;
		private IPAddress m_ip;
		private int m_port;

		private Exception m_lastConnectionError;

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

		public bool IsConnected
		{
			get { return m_client != null; }
		}

		public Exception LastConnectionError
		{
			get { return m_lastConnectionError; }
		}

		#endregion

		#region Constructor

		public ClientManager(IPAddress pIp, int pPort)
		{
			m_ip = pIp;
			m_port = pPort;
		}

		#endregion

		#region Connect / Stop

		public bool Connect()
		{
			if (IsConnected)
			{
				Disconnect();
			}
			m_client = new TcpClientHandler(m_ip, m_port);
			if(m_client.Connect())
			{
				m_client.Disconnected += m_client_Disconnected;
				m_client.ReceivedFull += m_client_ReceivedFull;
				return true;
			}

			m_lastConnectionError = m_client.LastConnectError;
			m_client = null;
			return false;
		}

		public void Disconnect()
		{
			if (!IsConnected)
				return;
			m_client.Disconnect();
			m_client = null;
		}

		#endregion

		public void SendMessage()
		{
			m_client.Send(Encoding.UTF8.GetBytes("Coucou!"));
		}

		void m_client_Disconnected(object sender, TcpEventArgs e)
		{
			m_client = null;
			if (OnDisconnected != null)
			{
				OnDisconnected(this, e);
			}
		}

		void m_client_ReceivedFull(object sender, TcpReceivedEventArgs e)
		{
			if (OnMessageReceived != null)
			{
				OnMessageReceived(this, e);
			}
		}

	}
}
