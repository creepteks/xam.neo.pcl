using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neo.pcl.Actions;

namespace neo.pcl
{
    class BaseState : IObservable<IBaseAction>
    {
        private Dictionary<TypeOfObserver, List<IObserver<IBaseAction>>> _observers;

        // methods
        public BaseState()
        {
            _observers = new Dictionary<TypeOfObserver, List<IObserver<IBaseAction>>>();
            _observers.Add(TypeOfObserver.ClientSide, new List<IObserver<IBaseAction>>());
            _observers.Add(TypeOfObserver.ServerSide, new List<IObserver<IBaseAction>>());
        }
        public void AddObserver(IObserver<IBaseAction> observer, TypeOfObserver type)
        {
            if (type == TypeOfObserver.ClientSide)
            {
                _observers[TypeOfObserver.ClientSide].Add(observer);
            }
            else if (type == TypeOfObserver.ServerSide)
            {
                _observers[TypeOfObserver.ServerSide].Add(observer);
            }
        }

        public virtual void Notify(IBaseAction action, TypeOfObserver type)
        {
            switch (type)
            {
                case TypeOfObserver.NotSet:
                    break;

                case TypeOfObserver.ClientSide:
                    InternalNotify(action, TypeOfObserver.ClientSide);
                    break;

                case TypeOfObserver.ServerSide:
                    InternalNotify(action, TypeOfObserver.ServerSide);
                    break;

                case TypeOfObserver.ClientSide | TypeOfObserver.ServerSide:
                    InternalNotify(action, TypeOfObserver.ClientSide);
                    InternalNotify(action, TypeOfObserver.ServerSide);
                    break;

                default:
                    break;
            }
        }

        private void InternalNotify(IBaseAction action, TypeOfObserver key)
        {
            for (int i = 0; i < _observers[key].Count; i++)
            {
                _observers[key][i].UpdateViewModel(action);
            }
        }

        public void RemoveObserver(IObserver<IBaseAction> observer)
        {
            if (_observers[TypeOfObserver.ClientSide].Contains(observer))
            {
                _observers[TypeOfObserver.ClientSide].Remove(observer);
            }
            else if (_observers[TypeOfObserver.ServerSide].Contains(observer))
            {
                _observers[TypeOfObserver.ServerSide].Remove(observer);
            }
        }
    }
}
