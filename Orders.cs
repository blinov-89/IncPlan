using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Orders
    {
        public string OrdersName { get; private set; }


        public Orders(string name)
        {
            OrdersName = name;

        }
    }
}
