using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        public static void Main()
        {
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 150, 222 });
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

            // Send the data through the socket.  
            int bytesSent = sender.Send(msg);
            Console.WriteLine("Sent shit: {0}", bytesSent);

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
