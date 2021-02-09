using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Department
    {
        public string DepartmentName { get; private set; }


        public Department(string name)
        {
            DepartmentName = name;

        }
    }
}
