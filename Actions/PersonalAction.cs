using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
      class PersonalAction : IFatAction<PersonalActionType, object>
    {
        private PersonalActionType _type;
        private TypeOfObserver _observationType = TypeOfObserver.NotSet;
        private object _content;

        // methods and properties
        public IFatAction<PersonalActionType, object> SetContent(object content)
        {
            _content = content;
            return this;
        }
        public object Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public IFatAction<PersonalActionType, object> SetType(PersonalActionType type)
        {
            _type = type;
            return this;
        }
        public PersonalActionType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public IFatAction<PersonalActionType, object> SetObservation(params TypeOfObserver[] observerTypes)
        {
            for (int i = 0; i < observerTypes.Length; i++)
            {
                _observationType |= observerTypes[i];
            }
            return this;
        }

        public TypeOfObserver Observation
        {
            get { return _observationType; }
            set { _observationType = value; }
        }
    }
}
