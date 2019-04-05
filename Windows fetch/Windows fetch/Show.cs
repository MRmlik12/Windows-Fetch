using System;
using System.Drawing;
//using Console = Colorful.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Windows_fetch
{
    public class Show
    {
        //Importing Classes
        public Resources.detect detect = new Resources.detect();
        public Resources.Diagnostic diagnostic = new Resources.Diagnostic();
        public Resources.hardware hardware = new Resources.hardware();
        public Resources.Memory memory = new Resources.Memory();
        public Resources.Config config = new Resources.Config();

        public List<String> CustomData()
        {
            List<String> data = new List<String> { };
            data.Add($"OS: { detect.OsInfo()}");
            data.Add($"Host: {hardware.PcModel()}");
            data.Add($"Processes: {diagnostic.Process()}");
            data.Add($"Resolution: {hardware.Resolution()}");
            data.Add($"CLR Version: {diagnostic.CLRVersion()}");
            data.Add($"UpTime: {diagnostic.UpTime()}");
            data.Add($"RAM: {memory.Summary()}");
            data.Add($"Cpu: {hardware.Cpu()}");
            data.Add($"Gpu: {hardware.Gpu()}");
            data.Add($"User: {diagnostic.CurrentUser()}");
            data.Add($"Root Dir: {diagnostic.WindowsDirectory()}");
            return data;
        }

        public List<String> BigPicture()
        {
            List<String> picture = new List<String> { };
            if (config.picture == "big")
            {
                picture.Add(@" __      __.__            .___                            ");
                picture.Add(@"/  \    /  \__| ____    __| _/______  _  ____  _  ________");
                picture.Add(@"\   \/\/   /  |/    \  / __ |/  _ \ \/ \/ /\ \/ \/ /  ___/");
                picture.Add(@" \        /|  |   |  \/ /_/ (  <_> )     /  \     /\___ \ ");
                picture.Add(@"  \__/\  / |__|___|  /\____ |\____/ \/\_/    \/\_//____  >");
                picture.Add(@"       \/          \/      \/                          \/ ");
            }
            else if (config.picture == "small")
            {
                picture.Add(@" __      __.__        ");
                picture.Add(@"/  \    /  \__| ____  ");
                picture.Add(@"\   \/\/   /  |/    \ ");
                picture.Add(@" \        /|  |   |  \");
                picture.Add(@"  \__/\  / |__|___|  /");
                picture.Add(@"       \/          \/ ");
            }
            return picture;
        }

        public void OnStart()
        {
            try
            {
                config.ReadConfig();
            }
            catch (FormatException)
            {
                Console.WriteLine($"The 'default' line of config.ini hasn't have a correct format" +
                    $". Try edit 'default' line as true or false!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            var versionMaj = 
                Environment.OSVersion.Version.Major;
            var versionMin =
                Environment.OSVersion.Version.Minor;
            if (versionMaj >= 6 && versionMin >= 2)
                if (config._default == true)
                    Modern();
                else
                    Custom();

            else if (versionMaj <= 6 && versionMin >= 1)
                    //Oldest();
                    if (config._default == true)
                        Oldest();
                    else if (config._default == false)
                        Custom();

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

        private void Custom()
        {
            int i = 0;
            CustomData();
            List<String> _data = CustomData();
            List<String> _picture = BigPicture();
            List<String> data = new List<String> { };
            int[] remove = config.remove;
            for (int x = 0; x < _data.Count; x++)
            { 
                if (remove[x] == 1)
                {
                    break;
                }
                if (remove[x] == 0)
                {
                    data.Add(_data[x]);
                }
            }
            int a = 0;
            try
            {
                if (config.picture == "small" && config.domain == false)
                {
                    Console.WriteLine($"                        {diagnostic.Domain()}");
                    Console.WriteLine($"                        ----------------------------");
                }
                else if (config.picture == "big" && config.domain == false)
                {
                    Console.WriteLine($"                                                            {diagnostic.Domain()}");
                    Console.WriteLine($"                                                            ----------------------------");
                }
                else if (config.domain == true)
                {

                }
                Console.WriteLine($"{_picture[a++]}  {data[i++]}", Color.Blue);
                Console.WriteLine($@"{_picture[a++]}  {data[i++]}", Color.Blue);
                Console.WriteLine($@"{_picture[a++]}  {data[i++]}", Color.Blue);
                Console.WriteLine($@"{_picture[a++]}  {data[i++]}", Color.Blue);
                Console.WriteLine($@"{_picture[a++]}  {data[i++]}", Color.Blue);
                Console.WriteLine($@"{_picture[a++]}  {data[i++]}", Color.Blue);
                if (config.picture == "small")
                {
                    Console.WriteLine($"                        {data[i++]}");
                    Console.WriteLine($"                        {data[i++]}");
                    Console.WriteLine($"                        {data[i++]}");
                    Console.WriteLine($"                        {data[i++]}");
                    Console.WriteLine($"                        {data[i++]}");
                }
                else if (config.picture == "big")
                {
                    Console.WriteLine($"                                                            {data[i++]}");
                    Console.WriteLine($"                                                            {data[i++]}");
                    Console.WriteLine($"                                                            {data[i++]}");
                    Console.WriteLine($"                                                            {data[i++]}");
                    Console.WriteLine($"                                                            {data[i++]}");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }
    }
}
