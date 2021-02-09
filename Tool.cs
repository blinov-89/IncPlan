using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class Tool
    {
        public string ToolName { get; private set; }

        public int ToolCod { get; private set; }

        public int OperationId { get; private set; }

        public Tool(string name, int toolCod, int opId)
        {
            ToolName = name;
            ToolCod = toolCod;
            OperationId = opId;


        }
    }
}
