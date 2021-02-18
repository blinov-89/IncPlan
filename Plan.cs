using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IncPlan
{
    public class Plan
    {
        public int PlanQuantity { get; private set; }

        public int OrdersId { get; private set; }

        public int CustomerId { get; private set; }

        public int ProductIdSAP { get; private set; }

        public int ReportId { get; private set; }

        public int StatusId { get; private set; }

        public int DocumentsId { get; private set; }

        public Plan(int planQuantity, int ordersId, int customerId, int productIdSAP, int reportId, int statusId, int documentId)
        {
            PlanQuantity = planQuantity;
            OrdersId = ordersId;
            CustomerId = customerId;
            ProductIdSAP = productIdSAP;
            ReportId = reportId;
            StatusId = statusId;
            DocumentsId = documentId;
        }
    }
}