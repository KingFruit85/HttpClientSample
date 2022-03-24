using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientSample
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

    public class Root
    {
        public Data data { get; set; }
    }

    // 
    // !!! An App.Config file needs to be created with the following values defined
    //
    //<? xml version="1.0" encoding="utf-8" ?>
    //<configuration>
    //  <appSettings>
    //    <add key = "URL" value="" />
    //    <add key = "URL_PARAMS" value="" />
    //    <add key = "AUTH_HEADER_VALUE" value=""/>
    //  </appSettings>
    //</configuration>


    class Program
    {
        static void Main(string[] args)
        {
            string URL = ConfigurationManager.AppSettings.Get("URL"); // The domain 

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            //Add and accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string authValue = ConfigurationManager.AppSettings.Get("AUTH_HEADER_VALUE"); // the auth value, such as bearer 1234gh45678fgfh8dfghg9x10
            client.DefaultRequestHeaders.Add("Authorization", authValue);

            // List data response
            string urlParameters = ConfigurationManager.AppSettings.Get("URL_PARAMS"); // The Endpoint : like v1/uptime/1234567
            HttpResponseMessage response = client.GetAsync(urlParameters).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body
                var r = response.Content.ReadAsAsync<Root>().Result;
                    Console.WriteLine($"{r.data.website_url} has an uptime score of {r.data.uptime}");
            }
            else
            {
                Console.WriteLine($"{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
        }
    }
}
