using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class EquipmentResult
    {
        public int EquipmentId { get; private set; }
        public string EquipmentName { get; private set; }
        public string EquipmentModel { get; private set; }
        public string DepartmentName { get; private set; }
        public string OperationName { get; private set; }


        public EquipmentResult(int equipmentId, string equipmentModel, string equipmentName, string departmentName, string operationName)
        {
            EquipmentId = equipmentId;
            EquipmentModel = equipmentModel;
            EquipmentName = equipmentName;
            DepartmentName = departmentName;
            OperationName = operationName;
        }
    }
}
