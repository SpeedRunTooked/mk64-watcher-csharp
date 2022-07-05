using System;
using Config;
using eep;
using mk64;

namespace MainSpace
{

    class RunProgram
    {
        public static void Main(string[] args)
        {
            //Test for correct reading of config file.
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            //cfg.display_cfg();

            //Test for correct reading of EEP file
            EepWatcher watcher = new EepWatcher();
            watcher.read_directly();
            watcher.display_eep();

            //Test for all_records data structure, print them to screen
            watcher.display_all_records();

            //Test for mk64.cs, compare two different all_records objects
            //Static void class so that we do not have to invoke class
            EepWatcher watcher2 = new EepWatcher();
            watcher2.read_directly();

            MK64.compare_reocrds(watcher.all_records, watcher2.all_records);


        }
    }
}