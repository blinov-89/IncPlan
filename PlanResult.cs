using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class PlanResult
    {
        public int Product_id_SAP { get; private set; }
        public string Product_name { get; private set; }
        public int Plan_quantity { get; private set; }
        public string Plan_time { get; private set; }
        public string Orders_name { get; private set; }
        public string Customer_name { get; private set; }
        public string Report_name { get; private set; }
        public string Status_name { get; private set; }
        public string Documents_name { get; private set; }

        public PlanResult(int product_id_SAP, string product_name, int plan_quantity, string plan_time,
            string orders_name, string customer_name,
            string report_name, string status_name, string documents_name)

        {
            Product_id_SAP = product_id_SAP;
            Product_name = product_name;
            Plan_quantity = plan_quantity;
            Plan_time = plan_time;
            Orders_name = orders_name;
            Customer_name = customer_name;
            Report_name = report_name;
            Status_name = status_name;
            Documents_name = documents_name;
        }
    }
}
