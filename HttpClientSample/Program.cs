using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace StatusCakeAPIDemo
{
    public class Data
    {
        public string id { get; set; }
        public bool paused { get; set; }
        public string name { get; set; }
        public string test_type { get; set; }
        public string website_url { get; set; }
        public int check_rate { get; set; }
        public int confirmation { get; set; }
        public List<string> contact_groups { get; set; }
        public bool do_not_find { get; set; }
        public bool enable_ssl_alert { get; set; }
        public bool follow_redirects { get; set; }
        public bool include_header { get; set; }
        public List<object> servers { get; set; }
        public bool processing { get; set; }
        public string status { get; set; }
        public List<object> tags { get; set; }
        public int timeout { get; set; }
        public int trigger_rate { get; set; }
        public int uptime { get; set; }
        public bool use_jar { get; set; }
        public DateTime last_tested_at { get; set; }
        public string next_location { get; set; }
        public List<string> status_codes { get; set; }
    }

    public class UptimeResponse
    {
        public Data data { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // These are all my Status Cake uptime monitoring test ids
            List<string> siteIds = new List<string> { "6336695", "6333769", "6333772", "6333774", "6333790", "6333791", "6333792", "6333793", "6333794", "6284257" };

            // Check the the most recent result of all the tests
            foreach (var id in siteIds)
            {
                var result = StatusCakeAPI.GetWebsiteUptime(id);

                if (result.data.status != "up")
                {
                    // Send warning somewhere?
                }

                Console.WriteLine($"{result.data.website_url} name is {result.data.status}. Last checked at: {result.data.last_tested_at}. The site has an uptime rating of {result.data.uptime}");


            }
            
        }
    }
}
