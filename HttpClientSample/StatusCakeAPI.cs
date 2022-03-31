using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StatusCakeAPIDemo
{
    static class StatusCakeAPI
    {

        public static UptimeResponse GetWebsiteUptime(string websiteID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.statuscake.com/");
            var response = new UptimeResponse();

            //Add and accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["BearerToken"]);

            try
            {
                // List data response
                HttpResponseMessage result = client.GetAsync($"v1/uptime/{websiteID}").Result;
                if (result.IsSuccessStatusCode)
                {
                    // Parse the response body
                    response = result.Content.ReadAsAsync<UptimeResponse>().Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong, Caught {e.GetType()} : {e.Message}");
            }
            finally
            {
                client.Dispose();
            }
            
            return response;
        }

    }
}
