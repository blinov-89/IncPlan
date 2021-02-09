using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Report
    {
        public string ReportNumber { get; private set; }

        public string ReportName { get; private set; }

        public int DepartmentId { get; private set; }

        public int SpecialtyId { get; private set; }

        public Report(string number, string name, int depart, int spec)
        {
            ReportNumber = number;
            ReportName = name;
            DepartmentId = depart;
            SpecialtyId = spec;
        }
    }
}
