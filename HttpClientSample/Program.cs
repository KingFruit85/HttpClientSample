using System;
using System.Collections.Generic;

namespace StatusCakeAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // These are all my Status Cake uptime monitoring test ids
            List<string> UptimeTestIds = new List<string> { "6336695", "6333769", "6333772", "6333774", "6333790", "6333791", "6333792", "6333793", "6333794", "6284257" };

            // Check the the most recent result of all the tests
            foreach (var id in UptimeTestIds)
            {
                var result = StatusCakeAPI.GetWebsiteUptime(id);

                if (result.data.status != "up")
                {
                    // If the site is down, carry out some specific action
                }

                // Print the result to the screen
                Console.WriteLine($"{result.data.website_url} name is {result.data.status}. Last checked at: {result.data.last_tested_at}. The site has an uptime rating of {result.data.uptime}");

            }

            // Check an SSL test ID
            var sslResult = StatusCakeAPI.GetSSLCheck("269823");
            Console.WriteLine($"Certificate status for {sslResult.data.website_url} is {sslResult.data.certificate_status}. The certificate expires on {sslResult.data.valid_until}");

            // Check a Page Speed test ID
            var pageSpeedResult = StatusCakeAPI.GetPageSpeed("95440");
            Console.WriteLine($"{pageSpeedResult.data.website_url} is {pageSpeedResult.data.latest_stats.filesize}kb. And last loaded in {pageSpeedResult.data.latest_stats.loadtime} /ms");

        }
    }
}