using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    class ReduxStore
    {
        private static ReduxStore _instance = new ReduxStore();
        public static ReduxStore instance
        {
            get { return _instance; }
        }

        // states which the ReduxStore knows about: actions are passed to specific states 
        PersonalState personalState = DependencyInjector.instance.Resolve<PersonalState>();
        //temp
        public void Dispatch(IBaseAction action)
        {
            if (action is IFatAction<PersonalActionType, object>)
            {
                personalState.TakeAction(action as IFatAction<PersonalActionType,object>);
            }
        }
    }
}
