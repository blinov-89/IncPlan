using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Material
    {
        public string MaterialName { get; private set; }

        public int MaterialCod { get; private set; }

        public int CiId { get; private set; }

        public Material(string name, int cod, int ci)
        {
            MaterialName = name;
            MaterialCod = cod;
            CiId = ci;
        }
    }
}


