using System;
using System.Collections.Generic;
using System.IO;
using TrackRecord;
using Config;

namespace eep
{
    class EepWatcher
    {
        public byte[]? eep_file;

        //public List<Dictionary<string, TrackRecords>> read_directly()
        public void read_directly()
        {
            //Get EEP file path from config file
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            string eepath = cfg.eep_path + cfg.eep_file;

            //Open EEP file
            eep_file = File.ReadAllBytes(eepath);

            //CALL TRACK RECORD HERE
            
        }

        public void display_eep()
        {
            //Print a bytelist f, specifically the EEP file
            Console.WriteLine("Display EEP file:");
            foreach (byte b in eep_file) { Console.Write(b + ","); };
            Console.WriteLine();
        }
    }
}
