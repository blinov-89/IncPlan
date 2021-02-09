using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Product
    {
        public string ProductlName { get; private set; }

        public float ProductTime { get; private set; }

        public Product(string name, float time)
        {
            ProductlName = name;
            ProductTime = time;
        }
    }
}