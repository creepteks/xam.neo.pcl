using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace neo.pcl
{
    class Shop_Simplified
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        public Shop_Simplified()
        {
            Name = "Massimo Dotti" + new Random(4).Next().ToString();
            ImagePath = "http://p30up.ir/uploads/f02715732.jpg";
        }
    }
}
