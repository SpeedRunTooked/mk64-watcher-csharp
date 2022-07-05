using System;
using System.Linq;
using TrackRecord;
using GameData;

namespace mk64
{
    class MK64
    {
        public static void compare_reocrds(TrackRecords[] original, TrackRecords[] newrecords)
        {
            /*
             * Take the original all_records array and compare it to the newly pulled all_records array
             * If they are the same, do nothing
             * If they are different, send time and print new record message for specific track
             * NOTE: We're only sending data if we either get a pb top 3-lap record or flap.
             * No data is sent if 3lap records 2-5 are achieved
             */

            int? three_lap_record;
            int? og_three_lap_record;
            int? flap_record;
            int? og_flap_record;

            //Iterate through all tracks
            for (int j = 0; j < 16; j++)
            {
                //Compare 3lap record
                og_three_lap_record = original[j].records[0][1];
                three_lap_record    = newrecords[j].records[0][1];
                if (three_lap_record != og_three_lap_record && three_lap_record != null){
                    //TODO - Write send logic here
                    Console.WriteLine("Three lap record mismatch! " + j + " " +  original[j].name);
                }

                //Compare flap record
                og_flap_record = original[j].records[5][1];
                flap_record = newrecords[j].records[5][1];
                if (flap_record != og_flap_record && flap_record != null)
                {
                    //TODO - Write send logic here
                    Console.WriteLine("F lap record mismatch! " + j + " " + original[j].name);
                }

                //Console.WriteLine("Done comparing: " + original[j].name + " and " + newrecords[j].name);
            }

        }
    }
}
