using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Specialty
    {
        public string SpecialtyName { get; private set; }


        public Specialty(string name)
        {
            SpecialtyName = name;

        }
    }
}
