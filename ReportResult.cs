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
        public string SpecialtyName { get; private set; }

        public ReportResult(string reportNumber, string reportName, string departmentName, string specialtyName)
        {
            ReportNumber = reportNumber;
            ReportName = reportName;
            DepartmentName = departmentName;
            SpecialtyName = specialtyName;
        }
    }
}
