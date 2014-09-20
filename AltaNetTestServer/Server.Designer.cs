using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;


namespace AltaNetTestServer
{
	partial class Server
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form
		private TextBox txtIp;

		private Label Ip;

		private Label label1;

		private TextBox txtPort;

		private TextBox txtLog;

		private Button btnStart;

		private Button btnStop;

		private Button btnSendFirst;

		private Button btnSendAll;

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtIp = new System.Windows.Forms.TextBox();
			this.Ip = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnSendFirst = new System.Windows.Forms.Button();
			this.btnSendAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIp
			// 
			this.txtIp.Location = new System.Drawing.Point(35, 6);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(59, 20);
			this.txtIp.TabIndex = 0;
			this.txtIp.Text = "127.0.0.1";
			// 
			// Ip
			// 
			this.Ip.AutoSize = true;
			this.Ip.Location = new System.Drawing.Point(12, 9);
			this.Ip.Name = "Ip";
			this.Ip.Size = new System.Drawing.Size(17, 13);
			this.Ip.TabIndex = 1;
			this.Ip.Text = "IP";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Port";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(35, 32);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(59, 20);
			this.txtPort.TabIndex = 2;
			this.txtPort.Text = "7878";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(116, 6);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(734, 231);
			this.txtLog.TabIndex = 4;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 58);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(82, 23);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(12, 87);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(82, 23);
			this.btnStop.TabIndex = 6;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnSendFirst
			// 
			this.btnSendFirst.Enabled = false;
			this.btnSendFirst.Location = new System.Drawing.Point(12, 199);
			this.btnSendFirst.Name = "btnSendFirst";
			this.btnSendFirst.Size = new System.Drawing.Size(82, 38);
			this.btnSendFirst.TabIndex = 7;
			this.btnSendFirst.Text = "Send 1st client";
			this.btnSendFirst.UseVisualStyleBackColor = true;
			this.btnSendFirst.Click += new System.EventHandler(this.btnSendFirst_Click);
			// 
			// btnSendAll
			// 
			this.btnSendAll.Enabled = false;
			this.btnSendAll.Location = new System.Drawing.Point(12, 155);
			this.btnSendAll.Name = "btnSendAll";
			this.btnSendAll.Size = new System.Drawing.Size(82, 38);
			this.btnSendAll.TabIndex = 8;
			this.btnSendAll.Text = "Send all client";
			this.btnSendAll.UseVisualStyleBackColor = true;
			this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
			// 
			// Server
			// 
			this.ClientSize = new System.Drawing.Size(862, 249);
			this.Controls.Add(this.btnSendAll);
			this.Controls.Add(this.btnSendFirst);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.Ip);
			this.Controls.Add(this.txtIp);
			this.Name = "Server";
			this.Text = "[Server] AltaNet Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}

