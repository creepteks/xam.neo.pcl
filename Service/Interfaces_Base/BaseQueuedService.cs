using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    public class BaseQueuedService
    {
        private List<Task> _synchronizationTasks;


        public BaseQueuedService()
        {
            _synchronizationTasks = new List<Task>();
        }
        public void AddTaskToTheQueue (Task task)
        {
            _synchronizationTasks.Add(task);
            ProcessNewTasks();
        }

        private async void ProcessNewTasks()
        {
            // we process tasks in a FIFO manner!
            for (int i = 0; i < _synchronizationTasks.Count; i++)
            {

            }


        }

        public void RemoveTaskFromQueue (Task task)
        {
            if (_synchronizationTasks.Contains(task))
            {
                _synchronizationTasks.Remove(task);
            }
        }

        public Task WhenFinishedAll()
        {
            return Task.WhenAll(_synchronizationTasks);
        }
    }
}
