using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigSetup.Instance.GetPath());
            ConfigSetup.Instance.ChangeConfigPath("D:\\ConfigFile");
            Console.WriteLine(ConfigSetup.Instance.GetPath());
            Console.ReadLine();
        }
    }


    public sealed class ConfigSetup
    {
        private static ConfigSetup _configSetup_Instance = null;
        private static string _path = null;
        private ConfigSetup()
        {
            _path ="C:\\configFiles";
        }

        public static ConfigSetup Instance
        {
            get
            {
                return _configSetup_Instance=_configSetup_Instance ?? new ConfigSetup();
            }
        }

        public string GetPath()
        {
             return  _path;
        }
        

        public void ChangeConfigPath(string path)
        {
            _path = path;
        } 
    }
}
