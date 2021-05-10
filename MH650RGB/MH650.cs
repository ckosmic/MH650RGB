using System;
using System.Linq;
using HidLibrary;

namespace MH650RGB
{
	public class MH650 {
		private const int _vid = 0x2516;
		private const int _pid = 0x0111;
		private static HidDevice _device;

		public static Action Inserted;
		public static Action Removed;
		public static bool Attached { get; private set; }

		private static void DeviceAttachedHandler() {
			Attached = true;
			Inserted.Invoke();
		}

		private static void DeviceRemovedHandler() {
			Attached = false;
			Removed.Invoke();
		}

		public static void Initialize() {
			_device = HidDevices.Enumerate(_vid, _pid).FirstOrDefault();
			_device.OpenDevice();

			_device.Inserted += DeviceAttachedHandler;
			_device.Removed += DeviceRemovedHandler;
		}

		public static void SetStaticLight(byte r, byte g, byte b, byte a) {
			_device.Write(Packet.CreateStaticRGBPacket(r, g, b, a));
		}

		public static void SetBreathingLight(byte r, byte g, byte b, byte a) {
			_device.Write(Packet.CreateBreathingRGBPacket(r, g, b, a));
		}

		public static void SetCyclingLight(byte a) {
			_device.Write(Packet.CreateCyclingRGBPacket(a));
		}

		public static void TurnOffLight() {
			_device.Write(Packet.CreateTurnOffRGBPacket());
		}

		public static void SetTest() {
			_device.Write(Packet.CreateTestPacket());
		}
	}
}
