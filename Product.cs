using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Product
    {
        public string ProductName { get; private set; }
        public int ProductIdSAP { get; private set; }
        public float ProductTime { get; private set; }

        public Product(string name, int productIdSAP, float time)
        {
            ProductName = name;
            ProductIdSAP = productIdSAP;
            ProductTime = time;
        }
    }
}