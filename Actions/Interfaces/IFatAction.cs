using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    // inherits from IBaseAction: the type of action with a content passed to the store and, then, reducer
    interface IFatAction<T,K>: IBaseAction
    {
        // funcitons in here make way for FLUENT API.
        IFatAction<T, K> SetType(T type);
        T Type { get; set; }
        IFatAction<T, K> SetObservation(TypeOfObserver[] observerType);
        TypeOfObserver Observation { get; set; }
        IFatAction<T,K> SetContent(K content);
        K Content { get; set; }
    }
}
