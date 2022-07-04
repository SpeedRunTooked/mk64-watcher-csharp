using System;
using GameData;

namespace TrackRecord
{
    class TrackRecords
    {
        public int[] build_record(byte[] bs)
        {
            /*
            Receive 24 bytes from EEP (which is all the data for a single track
            Return a logical object which has parsed out each record for that track.
            Each record consists of the top 5 fastest 3lap times, as well as the flap.
            The records are formatted by {'character': id, 'time': ms}
            */

            int[] track_records; //An array of all 6 'records' (which are arrays themselves), this is what we return

            //Iterate over each set of 3 bytes, which represents a single time for a single record
            for (int i = 0; i < 18; i += 3)
            {
                int a = bs[i + 0] >> 4;
                int b = bs[i + 0] & 0b00001111;
                int c = bs[i + 1] >> 4;
                int d = bs[i + 1] & 0b00001111;
                int e = bs[i + 2] >> 4;
                int f = bs[i + 2] & 0b00001111;

                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
                Console.WriteLine("c: " + c);
                Console.WriteLine("d: " + d);
                Console.WriteLine("e: " + e);
                Console.WriteLine("f: " + f);

                /*TODO - The numbers seem too big in the below calculation
                 * Looking at the python code, not sure why each value is multiplied by 2.
                 * Check in python, is each letter an int? or Byte?
                 * If so, what is each line returning as a value? (i.e. the f*2**16).
                 * track it each step of the way, figure out if we're doing equivalent things
                 * We're casting the above to int... but the numbers look right. Look at converting hex to int.


                /*
                //Calculate time, by multiplying the shifted bytes to their correspondant positional exponents
                int time = (Convert.ToInt32(Math.Pow(f * 2, 16)) +
                            Convert.ToInt32(Math.Pow(c * 2, 12)) +
                            Convert.ToInt32(Math.Pow(d * 2, 8 )) +
                            Convert.ToInt32(Math.Pow(a * 2, 4 )) +
                            b)*10;

                Console.WriteLine("Track Record: " + time);
                */
            }

            foreach (byte b in bs) { Console.Write(b + ","); };

            int[] x = { 1, 3 };
            return x;
        }

    }
}
