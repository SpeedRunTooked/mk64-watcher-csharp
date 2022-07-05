using System;
using System.Linq;
using GameData;

namespace TrackRecord
{
    class TrackRecords
    {
        //An array of all 6 'records' (which are arrays themselves) for a given track, this is what we return
        public int?[][] records = new int?[6][]; 

        public void build_record(byte[] bs)
        {
            /*
            Receive 24 bytes from EEP (which is all the data for a single track
            Return a logical object which has parsed out each record for that track.
            Each record consists of the top 5 fastest 3lap times, as well as the flap.
            The records are formatted by {'character': id, 'time': ms}
            */

            int?[] single_record = new int?[2]; //A single record for either 3lap or flap, contains [charID, timeMS]
            int? record_time; //The time in ms
            int? character; //the character ID
            int record_counter = 0;

            //Iterate over each set of 3 bytes, which represents a single time for a single record
            for (int i = 0; i < 18; i += 3)
            {
                int a = bs[i + 0] >> 4;
                int b = bs[i + 0] & 0b00001111;
                int c = bs[i + 1] >> 4;
                int d = bs[i + 1] & 0b00001111;
                int e = bs[i + 2] >> 4;
                int f = bs[i + 2] & 0b00001111;

                //Calculate time, by multiplying the shifted bytes to their correspondant positional exponents
                record_time = (f * Convert.ToInt32(Math.Pow(2, 16)) +
                                c * Convert.ToInt32(Math.Pow(2, 12)) +
                                d * Convert.ToInt32(Math.Pow(2, 8)) +
                                a * Convert.ToInt32(Math.Pow(2, 4)) +
                                b) * 10;

                character = e;

                //Check that time is not "default null time". Cannot do this in bytes, since we can't do comparisons between bytes
                if (record_time == 6000000)
                {
                    record_time = null;
                    character = null;
                }

                //Build our track_records array
                single_record[0] = character;
                single_record[1] = record_time;
                records[record_counter] = single_record;
                record_counter += 1;

            }
        }

    }
}
