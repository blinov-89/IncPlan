using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Status
    {
        public string StatusName { get; private set; }


        public Status(string name)
        {
            StatusName = name;

        }
    }
}
