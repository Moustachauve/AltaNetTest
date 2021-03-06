﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaNetTest.User;

namespace AltaNetTest
{
	#region NotificationReceived

	public class NotificationReceivedArgs : EventArgs
    {
        private readonly string m_notification;
        private readonly string m_type;
        public string Message
        {
            get { return m_notification; }
        }

        public string Type
        {
            get { return m_type; }
        }

        public NotificationReceivedArgs(string pMessage, string type)
        {
            m_notification = pMessage;
            m_type = type;
        }
	}

	#endregion

	#region Login Feedback

	public class LoginFeedbackArgs : EventArgs
	{
		private readonly bool m_succeeded;

		public bool Succeeded
		{
			get { return m_succeeded; }
		}

		public LoginFeedbackArgs(bool pSucceeded)
		{
			m_succeeded = pSucceeded;
		}
	}

	#endregion
}
