using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    [Flags]
    public enum TypeOfObserver
    {
        NotSet,
        ClientSide,
        ServerSide
    }
    public enum PersonalActionType
    {
        ProfilePicUpdate,
        NameUpdate,
        NotSet
    }
}
