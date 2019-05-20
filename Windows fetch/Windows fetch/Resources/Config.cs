using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IniParser;
using IniParser.Model;

namespace Windows_fetch.Resources
{
    public class Config
    {
        public int[] remove = new int[11];
        public bool _default;
        public string picture;
        public bool domain;

        public void ReadConfig()
        {
            var parser = new FileIniDataParser();
            IniData ini = parser.ReadFile("config.ini");
            KeyDataCollection getRemove = ini["WindowsFetch_Remove"];
            int i = 0;
            foreach (KeyData _getRemove in getRemove)
            {
                remove[i] = Int32.Parse(_getRemove.Value);
                i++;
            }
            _default = Boolean.Parse(ini["WindowsFetch"]["default"]);
            picture = ini["WindowsFetch"]["picture"];
            domain = Boolean.Parse(ini["WindowsFetch"]["remove_domain"]);
        }

        public void CheckConfigFile()
        {
            bool file = File.Exists("config.ini");
            if (file == false)
                CreateConfigFile();
        }

        private void CreateConfigFile()
        {
            var lines = ConfigLines();
            var _file = File.Create("config.ini");
            _file.Close();
            int counter = 0;
            File.WriteAllLines("config.ini", lines);
        }

        private List<String> ConfigLines()
        {
            List<String> Lines = new List<String> { };
            Lines.Add("[WindowsFetch]");
            Lines.Add("default=true");
            Lines.Add("picture=small");
            Lines.Add("remove_domain=false");
            Lines.Add("[WindowsFetch_Remove]");
            Lines.Add("1=0");
            Lines.Add("2=0");
            Lines.Add("3=0");
            Lines.Add("4=0");
            Lines.Add("5=0");
            Lines.Add("6=0");
            Lines.Add("7=0");
            Lines.Add("8=0");
            Lines.Add("9=0");
            Lines.Add("10=0");
            Lines.Add("11=0");
            return Lines;
        }
    }
}
