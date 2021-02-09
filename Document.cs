using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Document
    {
        public string DocumentName { get; private set; }


        public Document(string name)
        {
            DocumentName = name;

        }
    }
}
