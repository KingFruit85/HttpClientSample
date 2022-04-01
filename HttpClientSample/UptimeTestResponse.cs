using System;
using System.Collections.Generic;

namespace StatusCakeAPIDemo
{
    public class UptimeTestResponse
    {
        public class UptimeResponse
        {
            public Data data { get; set; }
        }

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
    }
}
