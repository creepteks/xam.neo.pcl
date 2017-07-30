using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core.Models
{
    class BaseModel
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore, Order = 1)]
        public string _id { get; set; } = null; // I love C# 6.0 (neo)
        public BaseModel(string id)
        {
            _id = id;
        }
    }
}
