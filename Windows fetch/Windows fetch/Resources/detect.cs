using System;
using Microsoft.Win32;
using System.Management;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_fetch.Resources
{
    #region os
    public class detect
    {
        public string a;
        public string b;

        public string OsInfo()
        {
            int osMajor = Environment.OSVersion.Version.Major;
            int osMinor = Environment.OSVersion.Version.Minor;

            switch (osMajor)
            {
                case 5:
                    //return "Windows XP";
                    switch (osMinor)
                    {
                        case 0:
                            b = collect(FullName());
                            return b;
                        case 1:
                            b = collect(FullName());
                            return b;
                        case 2:
                            b = collect(FullName());
                            return b;
                    }
                    break;
                case 6:
                    switch (osMinor)
                    {
                        case 0:
                            b = collect(FullName());
                            return b;
                        case 1:
                            b = collect(FullName());
                            return b;
                        case 2:
                            b = collect(FullName());
                            return b;

                        case 3:
                            b = collect(FullName());
                            return b;
                    }
                    break;   
                default:
                    return "Another Windows";
            }
            return a;
        }

        public string collect(string name)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                string OsName = name + " " + "x64";
                return OsName;
            }
            else
            {
                string OsName = name + " " + "x32";
                return OsName;
            }
        }

        public string FullName()
        {
            var registry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string windows = registry.GetValue("ProductName").ToString();
            return windows;
        }
    }
    #endregion

    #region hardware
    public class hardware
    {
        internal string cpuModel;
        internal string gpuModel;
        internal string _resolution;
        internal string pcModel;

        public string Cpu()
        {
            ManagementObjectSearcher _cpu = 
                new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject _object in _cpu.Get())
            {
                cpuModel = _object["Name"].ToString();
            }
            return cpuModel;
        }

        //problem with multi gpu
        public string Gpu()
        {
            ManagementObjectSearcher _gpu =
                new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject _object in _gpu.Get())
            {
                gpuModel = _object["Name"].ToString();
            }
            return gpuModel;
        }

        public string Resolution()
        {
            ManagementObjectSearcher _res =
                new ManagementObjectSearcher("select * from CIM_VideoControllerResolution");
            foreach (ManagementObject _object in _res.Get())
            {
                _resolution = 
                    _object["HorizontalR" +
                    "esolution"].ToString() + "x" + _object["VerticalResolution"].ToString();
            }
            return _resolution;
        }

        public string PcModel()
        {
            ManagementObjectSearcher _model =
                new ManagementObjectSearcher("select * from Win32_ComputerSystemProduct");
            foreach (ManagementObject _object in _model.Get())
            {
                pcModel = _object["Name"].ToString();
            }
            return pcModel;
        }
    }
    #endregion

    #region Diagnostic
    public class Diagnostic
    {
        internal string Times;
        internal string DNET;

        public string UpTime()
        {
            PerformanceCounter counter =
                new PerformanceCounter("System", "System Up Time");
            counter.NextValue();
            int _time = (int)counter.NextValue();
            int day = _time / 86400;
            int hours = _time / 3600 - day * 24;
            int minute = (_time / 60) % 60;
            //minute = 60 - (minute % 60);
            if (hours <= 0)
                Times = "minutes " + minute.ToString();
            else if (day >= 1)
                Times = "days " + day.ToString() + ", "
                    + "hours " + hours.ToString() + ", "
                    + "minutes " + minute.ToString();
            else if (day == 0)
                Times = "hours " + hours.ToString() + ", "
                   + "minutes " + minute.ToString();
            else
                Times = "days " + day.ToString() + ", "
                + "hours " + hours.ToString() + ", "
                + "minutes " + minute.ToString();

            return Times;
        }

        public string CLRVersion()
        {     
            return "v" + Environment.Version.ToString();
        }

        public int Process()
        {
            PerformanceCounter counter =
                new PerformanceCounter("System", "Processes");
            counter.NextValue();
            return (int)counter.NextValue();
        }

        public string ComputerName()
        {
            return Environment.MachineName;
        }

        public string Domain()
        {
            return Environment.UserName + "@" + Environment.UserDomainName;
        }

        public string CurrentUser()
        {
            return Environment.UserName;
        }

        public string WindowsDirectory()
        {
            return Environment.SystemDirectory;
        }
    }
    #endregion
}
