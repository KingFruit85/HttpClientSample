using System.Collections.Generic;

namespace StatusCakeAPIDemo
{
    class PageSpeedResponse
    {
        public class LatestStats
        {
            public int loadtime { get; set; }
            public double filesize { get; set; }
            public int requests { get; set; }
            public bool has_issue { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public bool paused { get; set; }
            public string name { get; set; }
            public string website_url { get; set; }
            public int check_rate { get; set; }
            public string location { get; set; }
            public List<object> contact_groups { get; set; }
            public int alert_smaller { get; set; }
            public int alert_bigger { get; set; }
            public int alert_slower { get; set; }
            public LatestStats latest_stats { get; set; }
        }

        public class PageSpeedTestResponse
        {
            public Data data { get; set; }
        }
    }
}
