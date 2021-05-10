using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH650RGB;

namespace MH650RGBTest
{
	class Program
	{
		static void Main(string[] args) {
			MH650.Initialize();
			MH650.SetStaticLight(255, 255, 0, 255);
			//MH650.SetBreathingLight(255, 255, 0, 255);
			MH650.TurnOffLight();
		}
	}
}
