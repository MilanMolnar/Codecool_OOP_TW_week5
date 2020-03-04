using Common;
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
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 150, 113 });
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            
            sender.Connect(remoteEP);

            //Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            //Measurement measuredData = new Measurement("value22", "type22");
            
            //Sensor sensordata = new Sensor("id22", measuredData);
            //Common.XMLHandler.SavetoXml(sensordata);

            sender.SendFile("Test.xml");
            
            Console.WriteLine("SENT");    

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
