
namespace JMCLoginTerminal
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelServerHost = new System.Windows.Forms.Label();
            this.textBoxServerHost = new System.Windows.Forms.TextBox();
            this.buttonServerConnect = new System.Windows.Forms.Button();
            this.buttonServerDisconnect = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxReceived = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelServerHost
            // 
            this.labelServerHost.AutoSize = true;
            this.labelServerHost.Location = new System.Drawing.Point(12, 9);
            this.labelServerHost.Name = "labelServerHost";
            this.labelServerHost.Size = new System.Drawing.Size(63, 13);
            this.labelServerHost.TabIndex = 0;
            this.labelServerHost.Text = "Server Host";
            // 
            // textBoxServerHost
            // 
            this.textBoxServerHost.Location = new System.Drawing.Point(12, 29);
            this.textBoxServerHost.Name = "textBoxServerHost";
            this.textBoxServerHost.Size = new System.Drawing.Size(212, 20);
            this.textBoxServerHost.TabIndex = 1;
            this.textBoxServerHost.Text = "\\\\.\\pipe\\JMCServer";
            // 
            // buttonServerConnect
            // 
            this.buttonServerConnect.Location = new System.Drawing.Point(231, 25);
            this.buttonServerConnect.Name = "buttonServerConnect";
            this.buttonServerConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonServerConnect.TabIndex = 2;
            this.buttonServerConnect.Text = "Connect";
            this.buttonServerConnect.UseVisualStyleBackColor = true;
            this.buttonServerConnect.Click += new System.EventHandler(this.buttonServerConnect_Click);
            // 
            // buttonServerDisconnect
            // 
            this.buttonServerDisconnect.Location = new System.Drawing.Point(231, 54);
            this.buttonServerDisconnect.Name = "buttonServerDisconnect";
            this.buttonServerDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonServerDisconnect.TabIndex = 3;
            this.buttonServerDisconnect.Text = "Disconnect";
            this.buttonServerDisconnect.UseVisualStyleBackColor = true;
            this.buttonServerDisconnect.Click += new System.EventHandler(this.buttonServerDisconnect_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(12, 80);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 129);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 96);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(212, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 145);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(212, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 54);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(118, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status : Not Connected";
            // 
            // textBoxReceived
            // 
            this.textBoxReceived.Enabled = false;
            this.textBoxReceived.Location = new System.Drawing.Point(12, 359);
            this.textBoxReceived.Multiline = true;
            this.textBoxReceived.Name = "textBoxReceived";
            this.textBoxReceived.ReadOnly = true;
            this.textBoxReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceived.Size = new System.Drawing.Size(330, 112);
            this.textBoxReceived.TabIndex = 11;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(235, 477);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(107, 22);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 171);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 14;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(235, 323);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(107, 23);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Visible = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Enabled = false;
            this.textBoxSend.Location = new System.Drawing.Point(12, 200);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSend.Size = new System.Drawing.Size(330, 117);
            this.textBoxSend.TabIndex = 10;
            this.textBoxSend.Visible = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 508);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxReceived);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonServerDisconnect);
            this.Controls.Add(this.buttonServerConnect);
            this.Controls.Add(this.textBoxServerHost);
            this.Controls.Add(this.labelServerHost);
            this.Name = "Client";
            this.Text = "Client Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelServerHost;
        private System.Windows.Forms.TextBox textBoxServerHost;
        private System.Windows.Forms.Button buttonServerConnect;
        private System.Windows.Forms.Button buttonServerDisconnect;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxReceived;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSend;
    }
}

