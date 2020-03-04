using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class ClientMenu
    {
        public void AskForIntervall()
        {

        }

        public void StartClient()
        {
            Console.Write("IP to connect: ");
            string ip = Console.ReadLine();
            string[] tmp=ip.Split(".");
            if(tmp.Length!=4)
            {
                throw new Exception("NotValidIP");
            }


            try
            {
                foreach(var item in tmp)
                {
                    byte.Parse(item);
                }
            }
            catch
            {
                throw new Exception("NotValidAttributes");
            }


            IPAddress ipAddress = new IPAddress(new byte[] { byte.Parse(tmp[0]), byte.Parse(tmp[1]),
                byte.Parse(tmp[2]), byte.Parse(tmp[3]) });

            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            Measurement measurement = new Measurement();
            
            Sensor sensordata = new Sensor();
            sensordata.AddMeasurement(measurement);
            XMLHandler.SavetoXml(sensordata);

            sender.SendFile("Test.xml");

            Console.WriteLine("SENT");

            StopClient(sender);
        }

        public void StopClient(Socket sender)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
