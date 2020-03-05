using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Common;

namespace Server
{
    public class Server
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void Main()
        {

            //var date = 1583407660898;
            //var datenow = DateTime.Now.Ticks;
            //var dateresult = datenow - date;
            //DateTime dateDate = new DateTime(dateresult);
            //var date2 = 637190113074752355;
            //DateTime dateDate2 = new DateTime(date2);
            //DateTime now = DateTime.Now;
            //var result = now - (dateDate);

            //Console.WriteLine(dateDate.ToString("yyyy'-'MM'-'dd'  'HH':'mm':'ss"));
            //Console.WriteLine(dateDate2.ToString("yyyy'-'MM'-'dd'  'HH':'mm':'ss"));
            //Console.ReadKey();


            //var date2 = DateTime.Now.Ticks;
            //DateTime date3 = new DateTime(date2);
            //Console.WriteLine(date3.ToString("yyyy'-'MM'-'dd'  'HH':'mm':'ss"));
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.WriteLine(DateTime.Now.Ticks);
            //Console.ReadKey();

            //Console.WriteLine(DateTime.Now.Millisecond);
            //Console.ReadKey();
            //192.168.150.15
            IPAddress ipAddress = IPAddress.Parse("192.168.150.36"); // google: how to get ipv4 in c#, elso talalat stackoverflow es nem lesz hardcodeolva. Just a tipp :)
            XMLTest();

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

        private static void XMLTest()
        {
            Dictionary<string, List<Measurement>> dict = XMLHandler.LoadFromXml();
            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key);
                foreach (var ele in kvp.Value)
                {
                    Console.WriteLine("\t" + ele);
                }
                Console.WriteLine();
            }
            XMLHandler.SaveDictToXML(dict);
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket client = listener.EndAccept(ar);

                //WHILE loop

                byte[] buff = new byte[1024];
                int bytesReads = client.Receive(buff);

                if (bytesReads < buff.Length)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("recieved.xml", false))
                    {
                        file.WriteLine(Encoding.ASCII.GetString(buff, 0, bytesReads));
                        Console.WriteLine("[INFO] Got data from {0}: bytes: {1} ", client.LocalEndPoint, bytesReads);
                    }
                }
                else
                {
                    Console.WriteLine("KEX");

                }
                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("exception");
            }
        }
    }
}