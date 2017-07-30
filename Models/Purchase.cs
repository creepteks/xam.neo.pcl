using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tag.Core
{
    public class Purchase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
