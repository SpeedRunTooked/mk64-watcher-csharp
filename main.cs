using System;
using Config;
using eep;

namespace MainSpace
{

    class RunProgram
    {
        public static void Main(string[] args)
        {
            //ConfigReader cfg = new ConfigReader();
            //cfg.get_config();
            //cfg.print_cfg();
            EepWatcher watcher = new EepWatcher();
            watcher.read_directly();

        }
    }

}