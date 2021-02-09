using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class EquipmentResult
    {
        public string EquipmentMode { get; private set; }
        public int EquipmentId { get; private set; }
        public string EquipmentName { get; private set; }
        public string DepartmentName { get; private set; }
        public string OperationName { get; private set; }


        public EquipmentResult(string equipmentMode, int equipmentId, string equipmentName, string departmentName, string operationName)
        {
            EquipmentMode = equipmentMode;
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            DepartmentName = departmentName;
            OperationName = operationName;
        }
    }
}
