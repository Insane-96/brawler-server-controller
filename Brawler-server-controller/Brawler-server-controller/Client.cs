using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace Brawler_server_controller
{
    public class Client
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        public Socket Socket { get; private set; }
        public IPEndPoint endPoint { get; private set; }

        public Client(string ip, int port)
        {
            this.Ip = ip;
            this.Port = port;

            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.endPoint = new IPEndPoint(IPAddress.Parse(this.Ip), this.Port);
        }

        public void SendPacket(Packet packet)
        {
            this.Socket.SendTo(packet.Data, this.endPoint);
        }
    }
}
