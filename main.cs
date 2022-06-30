using System;
using Config;

namespace MainSpace
{

    class RunProgram
    {
        public static void Main(string[] args)
        {
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            cfg.print_cfg();

        }
    }

}