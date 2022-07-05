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
            string eepath = cfg.eep_path + cfg.eep_file;
            //cfg.display_cfg();

            //Test for correct reading of EEP file
            EepBuilder watcher = new EepBuilder();
            watcher.read_directly(eepath);
            watcher.display_eep(eepath);

            //Test for all_records data structure, print them to screen
            watcher.display_all_records();

            //Test for mk64.cs, compare two different all_records objects
            //Static void class so that we do not have to invoke class
            EepBuilder watcher2 = new EepBuilder();
            watcher2.read_directly(eepath);

            MK64.compare_reocrds(watcher.all_records, watcher2.all_records);

            //NEXT STEP -- CREATE THE LOOP
        }
    }
}