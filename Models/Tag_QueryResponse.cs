using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
{
    enum TagDBTarget
    {
        SALT,
        REG,
        AUTH,

        CREATE,
        READ,
        UPDATE,
        DELETE
    }
    class Tag_QueryResponse
    {
        public static string CreateQuery(TagDBTarget target, string query)
        {
            string q = "{\"target\":\"" + target.ToString() + "\"";
            if (query != null)
            {
                q += ",\"query\":" + "\"" + query + "\"";
            }
            q += "}";

            //string q = "{\"target\":\"" + target.ToString() + "\",\"query\":" + query + "}";
            return q;
        }

    }
}
