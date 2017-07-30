using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    public class ThirdPartyAuthModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("picture")]
        public string ProfilePicture { get; set; }

    }
}
