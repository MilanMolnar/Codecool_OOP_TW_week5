using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void Main()
        {
            var date2 = DateTime.Now.Ticks;
            DateTime date3 = new DateTime(date2);
            Console.WriteLine(date3.ToString("yyyy'-'MM'-'dd'  'HH':'mm':'ss"));
            Console.WriteLine(DateTime.Now.Ticks);
            Console.WriteLine(DateTime.Now.Ticks);
            Console.ReadKey();

            Console.WriteLine(DateTime.Now.Millisecond);
            Console.ReadKey();
            IPAddress ipAddress = IPAddress.Parse("192.168.150.222"); // google: how to get ipv4 in c#, elso talalat stackoverflow es nem lesz hardcodeolva. Just a tipp :)
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12345);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                allDone.Reset();

                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                allDone.WaitOne();
            }
        }


        private static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket client = listener.EndAccept(ar);

            //WHILE loop

            byte[] buff = new byte[1024];
            int bytesReads = client.Receive(buff);

            if (bytesReads < buff.Length)
            {
                Console.WriteLine("PITE: {0} {1}", bytesReads, Encoding.ASCII.GetString(buff, 0, bytesReads));
            }
            else
            {
                Console.WriteLine("KEX");

            }
            client.Close();

        }
    }
}
