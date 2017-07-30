using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    //public enum ActionTypes
    //{

    //}
    interface IBaseAction
    {
        
        // base for all the actions which happen to our app states.
        // it's divided into two different interfaces: 
        // IFatActions (which are actions which carry objs as state modifiers, but right now we do not know anything about them)
        //and
        // ISlimActions (which just probably ! have a type and thats all!)
    }
}
