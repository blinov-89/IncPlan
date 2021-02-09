using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class MaterialResult
    {
        public string MaterialName { get; private set; }
        public int MaterialCod { get; private set; }
        public string CiName { get; private set; }

        public MaterialResult(string materialName, int materialCod, string ciName)
        {
            MaterialName = materialName;
            MaterialCod = materialCod;
            CiName = ciName;
        }
    }
}
