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
            ClientMenu clientMenu = new ClientMenu();
            clientMenu.StartClient();
        }
    }
}
