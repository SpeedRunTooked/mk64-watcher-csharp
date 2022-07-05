using System;
using System.Collections.Generic;
using System.IO;
using GameData;
using TrackRecord;
using Config;

namespace eep
{
    class EepBuilder
    {
        public byte[]? eep_file;
        public string? eepath;
        public TrackRecords[] all_records = new TrackRecords[16]; //list of all records

        public void read_directly()
        {
            /*
            Open EEP path, read as a list of bytes, call TrackRecords, and build array
            of all track records (all_records).
            */

            //Get EEP file path from config file
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            eepath = cfg.eep_path + cfg.eep_file;

            //Read 24 bytes from file, and call TrackRecord to build TrackRecords object for each track
            //Then read the next 24 bytes, etc etc.
            //We don't want to read the whole file, since there is a lot of stuff that's not needed
            //So just every 24 bits for every track.
            FileStream stream = new FileStream(eepath, FileMode.Open, FileAccess.Read);
            byte[] block = new byte[24];
            int i = 0;
            foreach (string track in Constants.TRACK_NAMES) {
                stream.Read(block, 0, 24);
                TrackRecords tr = new TrackRecords();
                tr.name = track;
                tr.build_record(block);
                all_records[i] = tr;
                i++;
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
        public void display_all_records()
        {
            //Display each track record object, specifically the data we care about.
            for (int i=0; i < 16; i++)
            {
                Console.WriteLine("Track: " + all_records[i].name);
                all_records[i].display_records();
            }
        }
    }

    class EepWatcher
}
