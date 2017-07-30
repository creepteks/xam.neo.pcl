using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    class PersonalState: BaseState, IState<IFatAction<PersonalActionType,object>>
    {
        private static PersonalState _instance = new PersonalState();

        public static PersonalState instance
        {
            get { return _instance; }
        }
        private string _name;

        public string name
        {
            get { return _name; }
        }


        // methods
        //constructor
        public PersonalState(): base()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            //debug stuff
            _name = "Ahmad";
        }
        public PersonalState SetName(string name)
        {
            _name = name;
            return this;
        }
        public void TakeAction(IFatAction<PersonalActionType, object> action)
        {
            if (action.Type == PersonalActionType.NameUpdate)
            {
                SetName((string)action.Content);
            }
            // in the end
            Notify(action, action.Observation);
        }
    }
}
