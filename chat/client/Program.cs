using System;
using System.Net.Sockets;
using System.Threading;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chat Client");
            ClientChat.Connect();
        }
    }

     public static class ClientChat
    {
        static string textBox1, textBox2, textBox3;

        static System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        static NetworkStream serverStream = default(NetworkStream);
        static string readData = null;

        public static void SendMsg()
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2 + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public static void Connect()
        {
            readData = "Conected to Chat Server ...";
            msg();
            clientSocket.Connect("127.0.0.1", 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox3 + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }

        private static void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[1000025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }

        private static void msg()
        {
            // if (this.InvokeRequired)
            //     this.Invoke(new MethodInvoker(msg));
            // else
            Console.WriteLine(readData);
                //textBox1 = textBox1 + Environment.NewLine + " >> " + readData;
        } 

    }
}
