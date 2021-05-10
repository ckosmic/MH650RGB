using System;
using System.Linq;
using HidLibrary;

namespace MH650RGB
{
	public class MH650RGB {
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

		public static void SetRGBA(byte r, byte g, byte b, byte a) {
			_device.Write(Packet.CreateRGBPacket(r, g, b, a));
		}
	}
}
