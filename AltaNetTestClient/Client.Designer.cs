namespace AltaNetTestClient
{
	partial class Client
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSend = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.Ip = new System.Windows.Forms.Label();
			this.txtIp = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSend
			// 
			this.btnSend.Enabled = false;
			this.btnSend.Location = new System.Drawing.Point(14, 205);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(82, 38);
			this.btnSend.TabIndex = 16;
			this.btnSend.Text = "Send a message";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(14, 93);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(82, 23);
			this.btnStop.TabIndex = 15;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(14, 64);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(82, 23);
			this.btnStart.TabIndex = 14;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(118, 12);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(734, 231);
			this.txtLog.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Port";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(37, 38);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(59, 20);
			this.txtPort.TabIndex = 11;
			this.txtPort.Text = "7878";
			// 
			// Ip
			// 
			this.Ip.AutoSize = true;
			this.Ip.Location = new System.Drawing.Point(14, 15);
			this.Ip.Name = "Ip";
			this.Ip.Size = new System.Drawing.Size(17, 13);
			this.Ip.TabIndex = 10;
			this.Ip.Text = "IP";
			// 
			// txtIp
			// 
			this.txtIp.Location = new System.Drawing.Point(37, 12);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(59, 20);
			this.txtIp.TabIndex = 9;
			this.txtIp.Text = "127.0.0.1";
			// 
			// Client
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 261);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.Ip);
			this.Controls.Add(this.txtIp);
			this.Name = "Client";
			this.Text = "[Client] AltaNet Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label Ip;
		private System.Windows.Forms.TextBox txtIp;
	}
}

