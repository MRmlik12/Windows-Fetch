using System;
using System.Drawing;
//using Console = Colorful.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_fetch
{
    public class Show
    {
        protected Resources.detect detect = new Resources.detect();
        protected Resources.Diagnostic diagnostic = new Resources.Diagnostic();
        protected Resources.hardware hardware = new Resources.hardware();
        protected Resources.Memory memory = new Resources.Memory();

        public void OnStart()
        {
            var versionMaj = 
                Environment.OSVersion.Version.Major;
            var versionMin =
                Environment.OSVersion.Version.Minor;
            if (versionMaj >= 6 && versionMin >= 2)
                Modern();
            else if (versionMaj <= 6 && versionMin >= 1)
                Oldest();
        }

        private void Oldest()
        {
            Console.WriteLine($"                         {diagnostic.Domain()}");
            Console.WriteLine($"                         ----------------------------");
            Console.WriteLine($" __      __.__           OS: {detect.OsInfo()}", Color.Blue);
            Console.WriteLine($@"/  \    /  \__| ____     Host: {hardware.PcModel()}", Color.Blue);
            Console.WriteLine($@"\   \/\/   /  |/    \    Processes: {diagnostic.Process()}",  Color.Blue);
            Console.WriteLine($@" \        /|  |   |  \   Resolution: {hardware.Resolution()}", Color.Blue);
            Console.WriteLine($@"  \__/\  / |__|___|  /   CLR Version: {diagnostic.CLRVersion()}", Color.Blue);
            Console.WriteLine($@"       \/          \/    UpTime: {diagnostic.UpTime()}", Color.Blue);
            Console.WriteLine($"                         RAM: {memory.Summary()}");
            Console.WriteLine($"                         Cpu: {hardware.Cpu()}");
            Console.WriteLine($"                         Gpu: {hardware.Gpu()}");
            Console.WriteLine($"                         User: {diagnostic.CurrentUser()}");
            Console.WriteLine($"                         Root Dir: {diagnostic.WindowsDirectory()}");
        }

        private void Modern()
        {
            Console.WriteLine($"                                                    {diagnostic.Domain()}");
            Console.WriteLine($"                                                    ----------------------------");
            Console.WriteLine($" __      __.__            .___                      OS: {detect.OsInfo()}", Color.Blue);
            Console.WriteLine($@"/  \    /  \__| ____    __| _/______  _  ________   Host: {hardware.PcModel()}", Color.Blue);
            Console.WriteLine($@"\   \/\/   /  |/    \  / __ |/  _ \ \/ \/ /  ___/   Processes: {diagnostic.Process()}",  Color.Blue);
            Console.WriteLine($@" \        /|  |   |  \/ /_/ (  <_> )     /\___ \    Resolution: {hardware.Resolution()}", Color.Blue);
            Console.WriteLine($@"  \__/\  / |__|___|  /\____ |\____/ \/\_//____  >   CLR Version: {diagnostic.CLRVersion()}", Color.Blue);
            Console.WriteLine($@"       \/          \/      \/                 \/    UpTime: {diagnostic.UpTime()}", Color.Blue);
            Console.WriteLine($"                                                    RAM: {memory.Summary()}");
            Console.WriteLine($"                                                    Cpu: {hardware.Cpu()}");
            Console.WriteLine($"                                                    Gpu: {hardware.Gpu()}");
            Console.WriteLine($"                                                    User: {diagnostic.CurrentUser()}");
            Console.WriteLine($"                                                    Root Dir: {diagnostic.WindowsDirectory()}");
        }
    }
}
