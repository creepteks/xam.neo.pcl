using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    class TagPersonStateSynchronizationService: BaseQueuedService
    {
        // fields
        private TagPersonModel _tagPerson;

        // properties and methods
        public Task Init()
        {
            // we first create a blank person
            _tagPerson = new TagPersonModel();
            // then we populate that with data from database
            AddTaskToTheQueue(RetrieveInitialPersonState());
            return WhenFinishedAll();
        }


        private Task RetrieveInitialPersonState()
        {
            throw new NotImplementedException();
        }
    }
}
