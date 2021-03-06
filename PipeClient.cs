using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JMCLoginTerminal
{
    class PipeClient
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
           String pipeName,
           uint dwDesiredAccess,
           uint dwShareMode,
           IntPtr lpSecurityAttributes,
           uint dwCreationDisposition,
           uint dwFlagsAndAttributes,
           IntPtr hTemplate);

        // Handles messages received from a server pipe
        // <param name="message">The byte message received</param>
        public delegate void MessageReceivedHandler(byte[] message);

        // Event is called whenever a message is received from the server pipe
        public event MessageReceivedHandler MessageReceived;


        // Handles server disconnected messages
        public delegate void ServerDisconnectedHandler();

        // Event is called when the server pipe is severed.
        public event ServerDisconnectedHandler ServerDisconnected;

        const int BUFFER_SIZE = 4096;

        FileStream stream;
        SafeFileHandle handle;
        Thread readThread;
        private bool connected;


        // Is this client connected to a server pipe
        public bool GetConnected()
        {
            return connected;
        }


        // Is this client connected to a server pipe
        private void SetConnected(bool value)
        {
            connected = value;
        }

        private string pipeName;

        // The pipe this client is connected to
        public string GetPipeName()
        {
            return pipeName;
        }

        // The pipe this client is connected to
        private void SetPipeName(string value)
        {
            pipeName = value;
        }

        // Connects to the server with a pipename.
        // <param name="pipename">The name of the pipe to connect to.</param>
        public void Connect(string pipename)
        {
            if (GetConnected())
            {
                throw new Exception("Already connected to pipe server.");
            }

            SetPipeName(pipename);

            handle =
               CreateFile(
                  GetPipeName(),
                  0xC0000000, // GENERIC_READ | GENERIC_WRITE = 0x80000000 | 0x40000000
                  0,
                  IntPtr.Zero,
                  3, // OPEN_EXISTING
                  0x40000000, // FILE_FLAG_OVERLAPPED
                  IntPtr.Zero);

            //could not create handle - server probably not running
            if (handle.IsInvalid)
            {
                return;
            }

            SetConnected(true);

            //start listening for messages
            readThread = new Thread(Read)
            {
                IsBackground = true
            };
            readThread.Start();
        }

        // Disconnects from the server.
        public void Disconnect()
        {
            if (!GetConnected())
            {
                return;
            }

            // we're no longer connected to the server
            SetConnected(false);
            SetPipeName(null);

            //clean up resource
            if (stream != null)
            {
                stream.Close();
            }
            handle.Close();

            stream = null;
            handle = null;
        }

        void Read()
        {
            stream = new FileStream(handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
            byte[] readBuffer = new byte[BUFFER_SIZE];

            while (true)
            {
                int bytesRead = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // read the total stream length
                        int totalSize = stream.Read(readBuffer, 0, 4);

                        // client has disconnected
                        if (totalSize == 0)
                            break;

                        totalSize = BitConverter.ToInt32(readBuffer, 0);

                        do
                        {
                            int numBytes = stream.Read(readBuffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));

                            ms.Write(readBuffer, 0, numBytes);

                            bytesRead += numBytes;

                        } while (bytesRead < totalSize);

                    }
                    catch
                    {
                        //read error has occurred
                        break;
                    }

                    //client has disconnected
                    if (bytesRead == 0)
                        break;

                    //fire message received event
                    if (MessageReceived != null)
                        MessageReceived(ms.ToArray());
                }
            }

            // if connected, then the disconnection was
            // caused by a server terminating, otherwise it was from
            // a call to Disconnect()
            if (GetConnected())
            {
                //clean up resource
                stream.Close();
                handle.Close();

                stream = null;
                handle = null;

                // we're no longer connected to the server
                SetConnected(false);
                SetPipeName(null);

                if (ServerDisconnected != null)
                    ServerDisconnected();
            }
        }

        // Sends a message to the server.
        // <param name="message">The message to send.</param>
        // <returns>True if the message is sent successfully - false otherwise.</returns>
        public bool SendMessage(byte[] message)
        {
            try
            {
                // write the entire stream length
                stream.Write(BitConverter.GetBytes(message.Length), 0, 4);

                stream.Write(message, 0, message.Length);
                stream.Flush();
                return true;
            }
            catch(IOException)
            {
                return false;
            }
        }
    }
}
