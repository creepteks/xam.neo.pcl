using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    interface IObserver<TBaseAction>
    {
        void UpdateViewModel(TBaseAction action);
    }
}
