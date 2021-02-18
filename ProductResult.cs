using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class ProductResult
    {
        public string Product_name { get; private set; }
        public int Product_id_SAP { get; private set; }
        public float Product_time { get; private set; }

        public ProductResult(string product_name, int product_id_SAP, float product_time)
        {
            Product_name = product_name;
            Product_id_SAP = product_id_SAP;
            Product_time = product_time;
        }
    }
}
