using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Operation
    {
        public string OperationName { get; private set; }


        public Operation(string name)
        {
            OperationName = name;

        }
    }
}
