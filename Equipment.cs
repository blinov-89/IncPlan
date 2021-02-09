using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Equipment
    {
        public string EquipmentName { get; private set; }

        public string EquipmentMode { get; private set; }

        public int DepartmentId { get; private set; }

        public int OperationId { get; private set; }


        public Equipment(string name; string mode; int department; int operation)
        {
            EquipmentName = name;
	        EquipmentMode = mode;
	        DepartmentId = department;
	        OperationId = operation;

        }
    }
}

