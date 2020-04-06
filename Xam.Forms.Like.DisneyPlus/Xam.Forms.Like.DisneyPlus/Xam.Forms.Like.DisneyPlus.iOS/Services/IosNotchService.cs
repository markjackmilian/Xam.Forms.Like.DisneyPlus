using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Foundation;
using Xam.Forms.Like.DisneyPlus.Services;

namespace Xam.Forms.Like.DisneyPlus.iOS.Services
{
    public class IosNotchService : INotchService
    {
        readonly List<string> iphonesWithNotch = new List<string>();

        public IosNotchService()
        {
            iphonesWithNotch.Add("iPhone10,3");
            iphonesWithNotch.Add("iPhone10,6");
            iphonesWithNotch.Add("iPhone11,2");
            iphonesWithNotch.Add("iPhone11,4");
            iphonesWithNotch.Add("iPhone11,6");
            iphonesWithNotch.Add("iPhone11,8");
            iphonesWithNotch.Add("iPhone12,1");
            iphonesWithNotch.Add("iPhone12,3");
            iphonesWithNotch.Add("iPhone12,5");
        }

        public bool DeviceHasNotch()
        {
            var device = CheckDeviceHardware("hw.machine");

            //Simulator
            if (device == "i386" || device == "x86_64")
            {
                var simulatorDevice = NSProcessInfo.ProcessInfo.Environment["SIMULATOR_MODEL_IDENTIFIER"].Description;
                if (iphonesWithNotch.Contains(simulatorDevice))
                {
                    return true;
                }
            }
            //Actual Device
            else if (iphonesWithNotch.Contains(device))
            {
                return true;
            }

            return false;
        }

        /*
         * From XLabs
         * https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Platform/XLabs.Platform.iOS/Device/AppleDevice.cs#L152
         */

        [DllImport("/usr/lib/libSystem.dylib")]
        internal static extern int sysctlbyname(
            [MarshalAs(UnmanagedType.LPStr)] string property,
            IntPtr output,
            IntPtr oldLen,
            IntPtr newp,
            uint newlen);

        public string CheckDeviceHardware(string property)
        {
            var pLen = Marshal.AllocHGlobal(sizeof(int));
            sysctlbyname(property, IntPtr.Zero, pLen, IntPtr.Zero, 0);
            var length = Marshal.ReadInt32(pLen);
            var pStr = Marshal.AllocHGlobal(length);
            sysctlbyname(property, pStr, pLen, IntPtr.Zero, 0);
            return Marshal.PtrToStringAnsi(pStr);
        }
    }
}