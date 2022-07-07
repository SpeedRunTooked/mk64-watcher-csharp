using System;
using System.Text;
using RestSharp;
using Config;

namespace uploader
{
    class Uploader
    {
        //Used in the parameter args
        private static string link_param = "MK64 Watcher";
        private static string notes_param = "Auto Rekt"; //TODO - allow this from cfg?

        public static string post_time(string track_slug, int? timeMsNullable, string record_type )
        {
            //get endpoint and user from config
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();

            //Use RestSharp to make a Post request to gus' website
            var client = new RestClient(cfg.db_endpoint);
            var request = new RestRequest("", Method.Post);

            //Convert timems to non-nullable -- See if we can change this in the program
            int timeMs =  timeMsNullable ?? default(int);

            //Add header and parameters to request object
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", cfg.username);
            request.AddParameter("trackSlug", track_slug);
            request.AddParameter("timeMs", timeMs);
            request.AddParameter("link", link_param);
            request.AddParameter("notes", notes_param);
            request.AddParameter("type", record_type);

            //Send it!
            RestResponse response = client.Execute(request);
            //Console.WriteLine("THE RESPONSE: " + response.StatusCode + " - " + response.Content);

            //Catch if username not found! Alert user
            //TODO - we should check this at the beginning of execution, gus will have to change his backend to have a check method
            if (response.StatusCode.ToString() != "OK")
            {
                Console.WriteLine(response.Content);
                Console.WriteLine("Time not uploaded! Please make sure username is typed correctly in the config.txt as it is in the website.");
                Console.WriteLine("Contact site administrator if you have not set up a username.");
                Console.WriteLine("Please fix issue and restart application to continue...");
            }

            return response.StatusCode.ToString();
        }
    }
}
