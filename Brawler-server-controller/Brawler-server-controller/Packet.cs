using System;
using System.IO;
using System.Net;

namespace Brawler_server_controller
{
    public enum Commands
    {
        Command = 98,
        ClientCommand = 99
    }

    public class Packet
    {
        public byte[] Data { get; private set; }
        public MemoryStream Stream { get; private set; }
        public BinaryReader Reader { get; private set; }
        public BinaryWriter Writer { get; private set; }
        public bool Broadcast { get; set; }
        // header
        public uint Id { get; private set; }
        public uint Time { get; private set; }
        public Commands Command { get; private set; }
        public int PayloadOffset { get; private set; }
        public int PacketSize { get; set; }

        public Packet(int packetSize, byte[] buffer, IPEndPoint remoteEp, Commands command)
        {
            PacketSize = packetSize;
            Data = buffer;
            Stream = new MemoryStream(Data);
            Reader = new BinaryReader(Stream);
            Writer = new BinaryWriter(Stream);

            AddHeaderToData(command);
        }

        public void AddHeaderToData(Commands command)
        {
            AddHeaderToData(Utils.GetPacketId(), command);
        }

        public void AddHeaderToData(uint id, Commands command)
        {
            Stream.Seek(0, SeekOrigin.Begin);

            Id = id;
            Command = command;
            Time = 0;

            Writer.Write(id);
            Writer.Write(Time);
            byte infoByte = (byte)command;
            Writer.Write(infoByte);

            PayloadOffset = (int)Stream.Position;
        }

        public override string ToString()
        {
            return $"packet:[Time:'{Time}', Id:'{Id}', Bc:'{Broadcast}', command:'{Command}']";
        }
    }
}