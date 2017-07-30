using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    public class SearchTagPageVM: ViewModelBase
    {
        public SearchTagPageVM()
        {
            // #revise: Feed it from a database or something else, probably an XML or JSON file
            AutoCompleteSuggestions = Consts.SearchTagSuggestions;
        }
        #region fields & properties
        // bindable props
        private string[] _autoCompleteSuggestions;
        public string[] AutoCompleteSuggestions
        {
            get
            {
                return _autoCompleteSuggestions;
            }
            set
            {
                _autoCompleteSuggestions = value;
                RaisePropertyChanged(() => AutoCompleteSuggestions);
            }
        }

        //    private List<string> _tagInquiries = new List<string>() { "شلوار", "پالتو" };

        //    public List<string> TagInquiries
        //    {
        //        get { return _tagInquiries; }
        //        set
        //        {
        //            _tagInquiries = value;
        //            RaisePropertyChanged(() => TagInquiries);
        //        }
        //    }
        //    private List<string> _hotTags = new List<string>() { "شلوار", "شال", "کیف", "زنانه", "بچگانه" };

        //    public List<string> HotTags
        //    {
        //        get { return _hotTags; }
        //        set
        //        {
        //            _hotTags = value;
        //            RaisePropertyChanged(() => HotTags);
        //        }
        //    }
    }
    #endregion
}
