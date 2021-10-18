using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMCLoginTerminal
{
    public partial class Client : Form
    {
        private PipeClient pipeClient;
        public Client()
        {
            InitializeComponent();
            CreateNewPipeClient();
        }
        void CreateNewPipeClient()
        {
            if (pipeClient != null)
            {
                pipeClient.MessageReceived -= pipeClient_MessageReceived;
                pipeClient.ServerDisconnected -= pipeClient_ServerDisconnected;
            }

            pipeClient = new PipeClient();
            pipeClient.MessageReceived += pipeClient_MessageReceived;
            pipeClient.ServerDisconnected += pipeClient_ServerDisconnected;
        }
        void pipeClient_ServerDisconnected()
        {
            Invoke(new PipeClient.ServerDisconnectedHandler(EnableConnectButton));
        }
        void EnableConnectButton()
        {
            buttonLogin.Enabled = true;
            buttonServerConnect.Enabled = true;
            textBoxServerHost.Enabled = true;
            labelStatus.Text = "Disconnected";
            textBoxReceived.Clear();
            disableBoxes();
        }
        void pipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(DisplayReceivedMessage),
                new object[] { message });
        }
        void DisplayReceivedMessage(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);

            if (str == "close")
            {
                pipeClient.Disconnect();

                CreateNewPipeClient();
                pipeClient.Connect(textBoxServerHost.Text);
            }
            if(str == "Login Successful")
            {
                enableBoxes();
                buttonLogin.Enabled = false;
                textBoxReceived.Clear();
            }
            textBoxReceived.Text += str + "\r\n";
        }

        private void buttonServerConnect_Click(object sender, EventArgs e)
        {
            pipeClient.Connect(textBoxServerHost.Text);

            if (pipeClient.GetConnected())
            {
                buttonServerConnect.Enabled = false;
                textBoxServerHost.Enabled = false;
                labelStatus.Text = "Server Connected";
            }
            else
            {
                labelStatus.Text = "Status: Could not connect";
            }
        }

        private void buttonServerDisconnect_Click(object sender, EventArgs e)
        {
            pipeClient.Disconnect();
            if (!pipeClient.GetConnected())
            {
                EnableConnectButton();
                labelStatus.Text = "Status: Not Connected";
                disableBoxes();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            pipeClient.SendMessage(encoder.GetBytes(textBoxSend.Text));
            clearTB();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxReceived.Clear();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (pipeClient.GetConnected())
            {
                ASCIIEncoding encoder = new ASCIIEncoding();

                pipeClient.SendMessage(encoder.GetBytes(textBoxUsername.Text + " " + textBoxPassword.Text));
                clearTB();
            }
            else
            {
                MessageBox.Show("Connect to a Server to Login.");
                clearTB();
            }
        }
        private void clearTB()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxSend.Clear();
        }
        private void enableBoxes()
        {
            textBoxSend.Visible = true;
            buttonSend.Visible = true;
            textBoxSend.Enabled = true;
            buttonSend.Enabled = true;
        }
        private void disableBoxes()
        {
            textBoxSend.Visible = false;
            buttonSend.Visible = false;
            textBoxSend.Enabled = false;
            buttonSend.Enabled = false;
        }
    }
}
