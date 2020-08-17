using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class My
    {
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        public static void OpenConsoleWindow()
        {
            AllocConsole();
        }

        public static void WriteConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void SleepSeconds(int second)
        {
            System.Threading.Thread.Sleep(second * 1000);
        }
    }
}
