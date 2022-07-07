using System;
using System.Text;
using Config;
using eep;
using mk64;
using RestSharp;

namespace MainSpace
{

    class RunProgram
    {
        public static void Main(string[] args)
        {
            //kick's off the watcher loop
            EepWatcher.watch_eep();
        }
        public static void TestMain()
        {
            test_https();
            /*
            //Test for correct reading of config file.
            ConfigReader cfg = new ConfigReader();
            cfg.get_config();
            string eepath = cfg.eep_path + cfg.eep_file;
            //cfg.display_cfg();

            //Test for correct reading of EEP file
            EepBuilder watcher = new EepBuilder();
            watcher.read_directly(eepath);
            watcher.display_eep(eepath);

            //Test for all_records data structure, print them to screen
            watcher.display_all_records();

            //Test for mk64.cs, compare two different all_records objects
            //Static void class so that we do not have to invoke class
            EepBuilder watcher2 = new EepBuilder();
            watcher2.read_directly(eepath);

            MK64.compare_reocrds(watcher.all_records, watcher2.all_records);
            */
        }

        public static void test_https()
        {
            /*Use RestSharp, an external package. VS can install it for you*/
            var client = new RestClient("https://us-central1-mk64-ad77f.cloudfunctions.net/addTime");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", "testPlayer");
            request.AddParameter("trackSlug", "kalimaridesert");
            request.AddParameter("timeMs", 700000);
            request.AddParameter("link", "none");
            request.AddParameter("notes", "notes go here");
            request.AddParameter("type", "3lap");
            RestResponse response = client.Execute(request);
            
            Console.WriteLine("THE RESPONSE: ");

            Console.WriteLine("Content: " + response.Content);
            Console.WriteLine("RawBytes: " + response.RawBytes);
            Console.WriteLine("ContentEncoding: " + response.ContentEncoding);
            Console.WriteLine("ContentLength: " + response.ContentLength);
            Console.WriteLine("ContentType: " + response.ContentType);
            Console.WriteLine("ErrorMessage: " + response.ErrorMessage);
            Console.WriteLine("ErrorException: " + response.ErrorException);
            Console.WriteLine("Headers: " + response.Headers);
            Console.WriteLine("ContentHeaders: " + response.ContentHeaders);
            Console.WriteLine("IsSuccessful: " + response.IsSuccessful);
            Console.WriteLine("ResponseStatus: " + response.ResponseStatus);
            Console.WriteLine("ResponseUri: " + response.ResponseUri);
            Console.WriteLine("Server: " + response.Server);
            Console.WriteLine("StatusCode: " + response.StatusCode);
            Console.WriteLine("StatusDescription: " + response.StatusDescription);
            Console.WriteLine("Request: " + response.Request);
            Console.WriteLine("RootElement: " + response.RootElement);

        }
    }
}