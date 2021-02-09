using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncPlan
{
    public class ToolResult
    { 
        public string ToolName { get; private set; }
        public int ToolCod { get; private set; }
        public string OperationName { get; private set; }

        public ToolResult(string toolName, int toolCod, string operationName)
        {
            ToolName = toolName;
            ToolCod = toolCod;
            OperationName = operationName;
        }
    }
}