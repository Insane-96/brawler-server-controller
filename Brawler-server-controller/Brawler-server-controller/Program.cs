using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brawler_server_controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(args[0], int.Parse(args[1]));

            string command = "";

            while (command != "exit")
            {
                command = Console.ReadLine();
                if (command == "test") {
                    byte[] data = new byte[512];
                    Packet packet = new Packet(data.Length, data, client.endPoint, Commands.Command);
                    client.SendPacket(packet);
                }
                Console.WriteLine("Command sent: " + command);
            }
        }
    }
}
