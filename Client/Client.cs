using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class Client
    {
        public byte[] ServerIPAddress { get; set; } = new byte[] { 192, 168, 150, 36 };
        public Sensor SensorData { get; set; }
        public int TimeInterval { get; set; } = 5000;
        bool connected = false;

        public void Start()
        {
            while (true)
            {
                IPAddress ipAddress = new IPAddress(ServerIPAddress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);
                // Create a TCP/IP  socket.  
                Socket sender = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    while (!connected)
                    {
                        try
                        {
                            // Connect the socket to the remote endpoint. Catch any errors. 
                            sender.Connect(remoteEP);
                            connected = true;
                        }
                        catch (SocketException)
                        {
                            System.Console.WriteLine("Unable to connect to server. Retrying...");
                        }
                    }
                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    XMLHandler.SavetoXml(SensorData);

                    sender.SendFile("measurement.xml");

                    Console.WriteLine("SENT");
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Thread.Sleep(TimeInterval);
                    connected = false;
                }
            }

        }
    }
}
