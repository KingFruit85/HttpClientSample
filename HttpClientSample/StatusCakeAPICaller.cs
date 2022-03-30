using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpClientSample
{
    static class StatusCakeAPICaller
    {

        public static UptimeResponse GetWebsiteUptime(string websiteID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.statuscake.com/");
            var response = new UptimeResponse();

            //Add and accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 301Arz8jIUnfQZOPH59gBFJ74GpaLv");

            // List data response
            HttpResponseMessage result = client.GetAsync($"v1/uptime/{websiteID}").Result;
            if (result.IsSuccessStatusCode)
            {
                // Parse the response body
                response = result.Content.ReadAsAsync<UptimeResponse>().Result;
            }
            else
            {
                Console.WriteLine($"{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
            }

            return response;
        }

    }
}
