﻿namespace MH650RGB
{
	class Packet
	{
		public static byte[] CreateRGBPacket(byte r, byte g, byte b, byte a) {
			return new byte[]	{ 0xFF,0x10,0x01,0x00,0x02,   a,   r,   g,   b,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
								  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
								  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
								  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
		}
	}
}
