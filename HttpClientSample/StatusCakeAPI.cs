using System;
using System.Configuration;
using System.Net.Http;
using static StatusCakeAPIDemo.PageSpeedResponse;
using static StatusCakeAPIDemo.UptimeTestResponse;

namespace StatusCakeAPIDemo
{
    static class StatusCakeAPI
    {
        public static UptimeResponse GetWebsiteUptime(string websiteID)
        {

            HttpClient client = new HttpClient();
            UptimeResponse response = new UptimeResponse();

            // Gets our secrect token from the App.config file and adds it to the request header
            client.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["BearerToken"]);

            try
            {
                // Make the request
                HttpResponseMessage result = client.GetAsync($"https://api.statuscake.com/v1/uptime/{websiteID}").Result;
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

        public static SSLTestResponse GetSSLCheck(string sslID)
        {
            HttpClient client = new HttpClient();
            SSLTestResponse response = new SSLTestResponse();

            // Gets our secrect token from the App.config file and adds it to the request header
            client.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["BearerToken"]);

            try
            {
                // Make the request
                HttpResponseMessage result = client.GetAsync($"https://api.statuscake.com/v1/ssl/{sslID}").Result;
                if (result.IsSuccessStatusCode)
                {
                    // Parse the response body
                    response = result.Content.ReadAsAsync<SSLTestResponse>().Result;
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

        public static PageSpeedTestResponse GetPageSpeed(string pageSpeedTestID)
        {
            HttpClient client = new HttpClient();
            PageSpeedTestResponse response = new PageSpeedTestResponse();

            // Gets our secrect token from the App.config file and adds it to the request header
            client.DefaultRequestHeaders.Add("Authorization", ConfigurationManager.AppSettings["BearerToken"]);

            try
            {
                // Make the request
                HttpResponseMessage result = client.GetAsync($"https://api.statuscake.com/v1/pagespeed/{pageSpeedTestID}").Result;
                if (result.IsSuccessStatusCode)
                {
                    // Parse the response body
                    response = result.Content.ReadAsAsync<PageSpeedTestResponse>().Result;
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