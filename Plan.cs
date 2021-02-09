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

        public string PlanDate { get; private set; }

        public float PlanTime { get; private set; }

        public float FactTime { get; private set; }

        public string PlanNote { get; private set; }

        public string PlanSap { get; private set; }

        public string ProductIdSAP { get; private set; }

        public int ReportId { get; private set; }

        public int StatusId { get; private set; }

        public int Documents_Id { get; private set; }


        public Plan(int planquantity; int ordersid; int customerid; string plandate; float plantime; float facttime; string plannote; string plansap; string productidsap; int reportid; int statusid; int documentid)
        {


            PlanQuantity = planquantity;;
	        OrdersId = ordersid;
	        CustomerId = customerid;
	        PlanDate = plandate;
	        PlanTime = plantime;
	        FactTime = facttime;
	        PlanNote = plannote;
	        PlanSap = plansap;
	        ProductIdSAP = productidsap;
	        ReportId = reportid;
	        StatusId = statusid;
	        Documents_Id = documentid;

	   	   
        }
    }
}
