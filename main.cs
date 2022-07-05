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
            //cfg.display_cfg();

            //Test for correct reading of EEP file
            EepWatcher watcher = new EepWatcher();
            watcher.read_directly();
            //watcher.display_eep();

            //Test for all_records data structure
            watcher.display_all_records();

            /*NEXT STEPS, THIS DOESN'T WORK!!!
             * 2 options
             * -- Write a method which takes 2 "watcher" objects, and iterates through them
             * -- Remake watcher, to return an array which has {name, record[6] = {character, time}}
             * ---- Or remove char to simplify?
             * ---- ??
             */

            EepWatcher watcher2 = new EepWatcher();
            watcher2.read_directly();

            if (watcher.all_records == watcher2.all_records)
            {
                Console.WriteLine("They Match!");
            } else
            {
                Console.WriteLine("They Don't");
            }

        }
    }
}