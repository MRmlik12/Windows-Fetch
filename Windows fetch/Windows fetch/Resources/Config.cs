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
    }
}
