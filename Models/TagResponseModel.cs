using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    [System.Obsolete("an extra abstracion which comes to no good")]
    public class TagResponseModel
    {
        [JsonProperty("finished")]
        public string finished { get; set; }

        [JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
        public string response { get; set; }
        public TagResponseModel(string finished, string response = null)
        {
            this.finished = finished;
            this.response = response;
        }
    }
}
