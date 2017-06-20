using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brawler_server_controller
{
    class Program
    {
        public enum CommanderCmds : byte
        {
            Ping = 0,
            ForceArena = 1,
            ForceLobby = 2,
            Kick = 3,
        }

        public static Dictionary<string, CommanderCmds> Commander = new Dictionary<string, CommanderCmds>()
        {
            { "ping", CommanderCmds.Ping },
            { "forcearena", CommanderCmds.ForceArena },
            { "forcelobby", CommanderCmds.ForceLobby },
            { "kick", CommanderCmds.Kick },
        };

        static void Main(string[] args)
        {
            Client client = new Client(args[0], int.Parse(args[1]));

            string command = "";

            while (command != "exit")
            {
                if (command != "")
                {
                    byte[] data = new byte[512];
                    Packet packet = new Packet(data.Length, data, client.endPoint, Commands.Command);
                    byte cmd = (byte)Commander[command];
                    packet.Writer.Write(cmd);
                    client.SendPacket(packet);
                }

                command = Console.ReadLine();
            }
        }
    }
}
