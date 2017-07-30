using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tag.Core
{
    class TagPersonModel
    {
        // fields related to a person which is saved on Database and retrieved as a TagPerson: These define a person in Tag world!
        // properties and methods: TagPersonModel Can do these through FLUENT API to be passed through the flow of the app
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string password { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string firstName { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string lastName { get; set; }

        [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        public string phoneNumber { get; set; }

        [JsonProperty("cellnumber", NullValueHandling = NullValueHandling.Ignore)]
        public string cellNumber { get; set; }

        [JsonProperty("numberofpurchases", NullValueHandling = NullValueHandling.Ignore)]
        public int numberOfPurchases { get; set; }

        [JsonProperty("popularityscore", NullValueHandling = NullValueHandling.Ignore)]
        public int popularityScore { get; set; }
    }
}
