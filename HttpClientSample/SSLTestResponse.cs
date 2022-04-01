using System;
using System.Collections.Generic;

namespace StatusCakeAPIDemo
{

    public class SSLTestResponse
    {
        public Data data { get; set; }
    }

    public class Flags
    {
        public bool is_extended { get; set; }
        public bool has_pfs { get; set; }
        public bool is_broken { get; set; }
        public bool is_expired { get; set; }
        public bool is_missing { get; set; }
        public bool is_revoked { get; set; }
        public bool has_mixed { get; set; }
        public bool follow_redirects { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public bool paused { get; set; }
        public int check_rate { get; set; }
        public string website_url { get; set; }
        public string issuer_common_name { get; set; }
        public string cipher { get; set; }
        public int cipher_score { get; set; }
        public int certificate_score { get; set; }
        public string certificate_status { get; set; }
        public List<object> contact_groups { get; set; }
        public List<int> alert_at { get; set; }
        public int last_reminder { get; set; }
        public bool alert_reminder { get; set; }
        public bool alert_expiry { get; set; }
        public bool alert_broken { get; set; }
        public bool alert_mixed { get; set; }
        public bool follow_redirects { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_until { get; set; }
        public DateTime updated_at { get; set; }
        public List<object> mixed_content { get; set; }
        public Flags flags { get; set; }
    }

    
}
