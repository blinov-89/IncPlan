using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class ReportResult
    {
        public string ReportNumber { get; private set; }
        public string ReportName { get; private set; }
        public string DepartmentName { get; private set; }
        public int SpecialtyId { get; private set; }

        public ReportResult(string reportNumber, string reportName, string departmentName, int specialtyId)
        {
            ReportNumber = reportNumber;
            ReportName = reportName;
            DepartmentName = departmentName;
            SpecialtyId = specialtyId;
        }
    }
}
