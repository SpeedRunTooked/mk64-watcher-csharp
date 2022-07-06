/*
Reads the config.yml file and returns it as a struct
The config.yml file contains the personalized configuration
parameters needed for our program to work
*/
using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Config
{
    class ConfigReader
    {
        /// ConfigFile structure, these are the fields in our config.yml file
        public string? username;
        public string? eep_path;
        public string? eep_file;
        public string? db_endpoint;

        public void get_config()
        {
            //Read config file and parse out into each member variable
            string[] fileText = File.ReadAllLines("config.txt");

            username = parse_yaml_line(fileText[0]);
            eep_path = parse_yaml_line(fileText[1]);
            eep_file = parse_yaml_line(fileText[2]);
            db_endpoint = parse_yaml_line(fileText[3]);

        }
        public void display_cfg()
        {
            //Test method to print out our member values
            Console.WriteLine("Displaying config file: ");
            Console.WriteLine("Username: " + username);
            Console.WriteLine("eep_path: " + eep_path);
            Console.WriteLine("eep_file: " + eep_file);
            Console.WriteLine("db_endpoint: " + db_endpoint);
        }

        private string parse_yaml_line(string fileline)
        {
            //provide a list of delimeters
            //Split the string, and return only what's on the right hand side of any ":"
            string[] delimeters = { " : ", ": ", ":"};
            string[] words = fileline.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            //Drop the first element, combine the rest of the array elements
            //We have to do this since one of the text fields is a url, which has https://...
            words = words.Skip(1).ToArray();
            return string.Join(":",words);
        }
    }
}
