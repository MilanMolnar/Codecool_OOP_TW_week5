using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class ClientMenu
    {
        public void AskForIntervall()
        {

        }

        public void StartClient()
        {
            //Console.Write("IP to connect: ");
            //string ip = Console.ReadLine();
            //string[] tmp=ip.Split(".");
            //if(tmp.Length!=4)
            //{
            //    throw new Exception("NotValidIP");
            //}


            //try
            //{
            //    foreach(var item in tmp)
            //    {
            //        byte.Parse(item);
            //    }
            //}
            //catch
            //{
            //    throw new Exception("NotValidAttributes");
            //}
        }
        public static void Main()
        {
            Client client = new Client();
            client.Start();
        }
    }
}
