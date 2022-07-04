using System;
using Config;
using eep;

namespace MainSpace
{

    class RunProgram
    {
        public static void Main(string[] args)
        {
            //Test for correct reading of config file.
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            cfg.display_cfg();

            //Test for correct reading of EEP file
            EepWatcher watcher = new EepWatcher();
            watcher.read_directly();
            //watcher.display_eep();

        }
    }
}