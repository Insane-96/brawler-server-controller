using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brawler_server_controller
{
    public static class Utils
    {
        public static uint PacketId;

        static Utils()
        {
            PacketId = 0;
        }

        public static uint GetPacketId()
        {
            return PacketId++;
        }

        public static byte SetBitOnByte(byte b, int pos, bool value)
        {
            return value ? (byte)(b | (1 << pos)) : (byte)(b & ~(1 << pos));
        }

        public static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
    }
}
