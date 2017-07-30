using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    [System.Obsolete("an extra abstracion which comes to no good")]
    public class TagQueryModel
    {
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string accsessToken { get; set; }
        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string target { get; set; }

        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string query { get; set; }
        public TagQueryModel(string target = null, string query = null, string accessToken = null)
        {
            this.accsessToken = accsessToken;
            this.target = target;
            this.query = query;
        }
    }
}
