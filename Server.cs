using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace JMCServer
{
    public partial class Server : Form
    {
        private PipeServer pipeServer = new PipeServer();
        List <User> accounts = new List<User>();

        public bool IsBackground { get; private set; }

        public Server()
        {
            InitializeComponent();

            pipeServer.MessageReceived += pipeServer_MessageReceived;
            pipeServer.ClientDisconnected += pipeServer_ClientDisconnected;
        }
        void pipeServer_ClientDisconnected()
        {
            Invoke(new PipeServer.ClientDisconnectedHandler(ClientDisconnected));
        }
        void ClientDisconnected()
        {
            refreshConnectionLabel();
            MessageBox.Show("Client Disconnected");
        }
        void pipeServer_MessageReceived(byte[] message)
        {
            Invoke(new PipeServer.MessageReceivedHandler(DisplayMessageReceived),
                new object[] { message });
        }

        void DisplayMessageReceived(byte[] message)
        {
            //ASCIIEncoding encoder = new ASCIIEncoding();
            //string str = encoder.GetString(message, 0, message.Length);
            //textBoxReceived.Text += str + "\r\n";

            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            string[] words = str.Split(' ');

            validatePassword(words[0], words[1]);
            textBoxReceived.Text += str + "\r\n";
            refreshConnectionLabel();
        }
        //void loginVerification(byte[] message)
        //{
        //    ASCIIEncoding encoder = new ASCIIEncoding();
        //    string str = encoder.GetString(message, 0, message.Length);
        //    string[] words = str.Split(' ');

        //    validatePassword(words[0], words[1]);
        //    textBoxReceived.Text += str + "\r\n";
        //}

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            //start the pipe server if it's not already running
            if (!pipeServer.GetRunning())
            {
                pipeServer.Start(textBoxServerName.Text);
                labelServerStatus.Text = "Status: Server is Running.";
                buttonStartServer.Enabled = false;
                refreshConnectionLabel();
            }
            else
                MessageBox.Show("Server already running.");
        }
        private void refreshConnectionLabel()
        {
            labelClientConnections.Text = "Connections: " + pipeServer.TotalConnectedClients.ToString();            
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] messageBuffer = encoder.GetBytes(textBoxSend.Text);

            pipeServer.SendMessage(messageBuffer);
            textBoxSend.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxReceived.Clear();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (pipeServer.GetRunning())
                {
                    if (!(String.IsNullOrEmpty(textBoxUsername.Text) || String.IsNullOrEmpty(textBoxPassword.Text)))
                    {
                        string password = textBoxPassword.Text;
                        string hashedPassword = GetHashPassword(textBoxPassword.Text);
                        string username = textBoxUsername.Text;
                        User newUser = new User(username, password, hashedPassword);
                        accounts.Add(newUser);

                        ASCIIEncoding encoder = new ASCIIEncoding();
                        byte[] messageBuffer = encoder.GetBytes("Login Credentials . . . ");
                        byte[] messageBufferUser = encoder.GetBytes("Username: " + newUser.getUser());
                        byte[] messageBufferPass = encoder.GetBytes("Password: " + newUser.getPassword());

                        pipeServer.SendMessage(messageBuffer);
                        pipeServer.SendMessage(messageBufferUser);
                        pipeServer.SendMessage(messageBufferPass);
                        refreshConnectionLabel();
                        updateUserList();
                        clearTB();
                    }
                    else
                    {
                        MessageBox.Show("Fill User and Password Fields");
                        clearTB();
                        textBoxUsername.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Turn Server On");
                }
            }
            catch(ArgumentException)
            {
                MessageBox.Show("User Already Exists");
            }
        }
        private void clearTB()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }
        private void updateUserList()
        {
            listBoxUsers.Items.Clear();
            foreach(User user in accounts)
            {
                listBoxUsers.Items.Add("User: " + user.getUser());
                listBoxUsers.Items.Add("Password: " + user.getPassword());
                listBoxUsers.Items.Add("Hash: " + user.GetHashedPassword());
            }
            refreshConnectionLabel();
        }
        private string GetHashPassword(string password)
        {          
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }
        private bool validatePassword(string username, string passwordAttempt)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            bool validated = false;
            bool usernameValidated = false;
            /* Fetch the stored value */
            foreach (User user in accounts)
            {
                string savedUsername = user.getUser();
                string savedPasswordHash = user.GetHashedPassword();

                if (savedUsername.Equals(username))
                {
                    usernameValidated = true;
                }
                else
                {
                    usernameValidated = false;
                }
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(passwordAttempt, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        validated = false;
                        //throw new UnauthorizedAccessException();
                    }
                    else
                    {
                        validated = true;
                    }
                }
            }
            if (validated && usernameValidated)
            {
                validateStatus.Text = "Validated";

                byte[] messageBuffer = encoder.GetBytes("Login Successful");
                pipeServer.SendMessage(messageBuffer);
            }
            else
            {
                validateStatus.Text = "Not Validated";

                byte[] messageBuffer = encoder.GetBytes("Login Unsuccessful");
                pipeServer.SendMessage(messageBuffer);
            }

            return validated;
        }
    }
}
