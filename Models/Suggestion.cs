using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    class Suggestion
    {
        public string suggestionName { get; private set; }
        public string suggestionImagePath { get; private set; }
        public string suggestionLink { get; private set; }
        public string suggestionGeolocation { get; private set; }
        public string suggestionTelegramID { get; private set; }
        public string suggestionPhonenumber { get; private set; }
        public string suggestionInstagramID{ get; private set; }
        public string suggestionWebAddress { get; set; }
        public bool suggestionIsOffsale { get; set; }
        public int suggestionOffPercent { get; set; }

        public Suggestion()
        {
            // #test
            suggestionImagePath = "http://p30up.ir/uploads/f02715732.jpg";
            suggestionName = "New Suggestion" + new Random(5).Next().ToString();
        }
    }
}
