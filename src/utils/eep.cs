using System;
using System.Collections.Generic;
using System.IO;
using GameData;
using TrackRecord;
using Config;

namespace eep
{
    class EepWatcher
    {
        public byte[]? eep_file;
        public string? eepath;

        //public List<Dictionary<string, TrackRecords>> read_directly()
        public void read_directly()
        {
            /*
            Open EEP path, read as a list of bytes, call TrackRecords, and return an array
            of all track records.
            */

            //Get EEP file path from config file
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            eepath = cfg.eep_path + cfg.eep_file;

            //List of track records (16 tracks)
            //NOTE, to add a line, we would do like:
                //all_records[0] = new int[2];
                //all_records[1] = new int[2];
                //...
            //OR
                //all_records[0] = new int[] {"1", "12345"}
                //...
            int[][] all_records = new int[16][];

            //Read 24 bytes from file, and call TrackRecord to build TrackRecords object for each track
            //Then read the next 24 bytes, etc etc.
            FileStream stream = new FileStream(eepath, FileMode.Open, FileAccess.Read);
            byte[] block = new byte[24];
            int i = 0;
            foreach (string track in Constants.TRACK_NAMES) {
                Console.WriteLine("Parsing " + track);
                stream.Read(block, 0, 24);
                TrackRecords tr = new TrackRecords();
                all_records[i] = tr.build_record(block);
            };
            stream.Close();
        }

        public void display_eep()
        {
            //Print bytelist file, specifically the EEP file

            //Open EEP file
            eep_file = File.ReadAllBytes(eepath);

            //Display it
            Console.WriteLine("Display EEP file:");
            foreach (byte b in eep_file) { Console.Write(b + ","); };
            Console.WriteLine();
        }
    }
}
