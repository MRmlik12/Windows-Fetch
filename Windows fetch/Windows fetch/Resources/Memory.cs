using System;
using System.Collections.Generic;
using System.Management;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Windows_fetch.Resources
{
    public class Memory
    {
        public long fullm;

        internal int UsageNemory()
        {
            PerformanceCounter fullRam = new PerformanceCounter("Memory", "Available MBytes", true);
            return Convert.ToInt32(fullRam.NextValue());
        }
        
        public string Summary()
        {
            int usage = UsageNemory();
            ManagementObjectSearcher ram =
                new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject _object in ram.Get())
            {
                fullm = Convert.ToInt64(_object["TotalPhysicalMemory"]);
            }
            var convert = fullm / 1048576;
            string avaliable = $"{convert - usage}/{convert} [MB]";
            return avaliable;
        }
    }
}
