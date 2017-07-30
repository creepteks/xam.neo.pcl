using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    interface IObservable<TBaseAction>
    {
        void AddObserver(IObserver<TBaseAction> observer, TypeOfObserver type);
        void RemoveObserver(IObserver<TBaseAction> observer);
        void Notify(TBaseAction action, TypeOfObserver type);
    }
}
