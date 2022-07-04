using System;
using System.Collections.Generic;
using System.IO;
using TrackRecord;
using Config;

namespace eep
{
    class EepWatcher
    {
        //public List<Dictionary<string, TrackRecords>> read_directly()
        public void read_directly()
        {
            //Get EEP file path from config file
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            string eepath = cfg.eep_path + cfg.eep_file;

            //Open EEP file
            byte[] f = File.ReadAllBytes(eepath);

            //Print the EEP file
            display_eep(f);


            //CALL TRACK RECORD HERE
            
        }

        static void display_eep(byte[] f)
        {
            //Print a bytelist f, specifically the EEP file
            Console.WriteLine("Display EEP file:");
            foreach (byte b in f) { Console.Write(b + ","); };
            Console.WriteLine();
        }
    }
}
