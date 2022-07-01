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

        }
    }
}
