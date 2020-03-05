using System;
using Server;

namespace GreenCommitment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].ToLower().Equals("server"))
            {
                Server.Server.Main();
            }
            else
            {
                Client.ClientMenu.Main();
            }
        }
    }
}
