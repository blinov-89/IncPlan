using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace IncPlan
{
    public class SQLiteDataBase
    {
        public string ConnectedDB { get; private set; }

        public SQLiteConnection Connection { get; private set; }

        public SQLiteCommand Command { get; set; }

        public SQLiteDataBase(string url)
        {
            ConnectedDB = url;
            Connection = new SQLiteConnection(ConnectedDB);
            Command = new SQLiteCommand(Connection);
        }

        public void AddNewTool(Tool tool)
        {
            Connection.Open();
            Command.CommandText = "INSERT INTO tools (tool_name, tool_cod, operation_id)" +
                                  "VALUES (@name, @toolcod, @operationid)";

            Command.Parameters.AddWithValue("@name", tool.ToolName);
            Command.Parameters.AddWithValue("@toolcod", tool.ToolCod);
            Command.Parameters.AddWithValue("@operationid", tool.OperationId);


            Command.ExecuteNonQuery();

            //UpdateToolMachTypes(tool.MachTypes);

            Connection.Close();
        }

        public void AddNewMaterial(Material material)
        {
            Connection.Open();
            Command.CommandText = "Material INTO materials (material_name, ci_id) VALUES (@name, @mode, @ci)";
            Command.Parameters.AddWithValue("@name", material.MaterialName);
            Command.Parameters.AddWithValue("@cod", material.MaterialCod);
            Command.Parameters.AddWithValue("@ci", material.CiId);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void AddNewOrder(Orders order)
        {
            Connection.Open();
            Command.CommandText = "Order INTO orders (orders_name) VALUES (@name)";
            Command.Parameters.AddWithValue("@name", order.OrdersName);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void AddNewReport(Report report)
        {
            Connection.Open();
            Command.CommandText = "Report INTO report (report_number, report_name, department_id, specialty_id) VALUES (@number, @name, @depart, @spec)";
            Command.Parameters.AddWithValue("@number", report.ReportNumber);
            Command.Parameters.AddWithValue("@name", report.ReportName);
            Command.Parameters.AddWithValue("@depart", report.DepartmentId);
            Command.Parameters.AddWithValue("@spec", report.SpecialtyId);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void AddNewProduct(Product product)
        {
            Connection.Open();
            Command.CommandText = "Product INTO product (product_name, product_time) VALUES (@name, @time)";
            Command.Parameters.AddWithValue("@name", product.ProductlName);
            Command.Parameters.AddWithValue("@time", product.ProductTime);
            Command.ExecuteNonQuery();
            Connection.Close();
        }






        //public void AddNewInsertMaterial(string name, List<CuttingCondition> conditions)
        //{
        //    Connection.Open();
        //    Command.CommandText = "INSERT INTO insert_materials (mat_name) VALUES (@name)";
        //    Command.Parameters.AddWithValue("@name", name);
        //    Command.ExecuteNonQuery();
        //    UpdateInsertProcMaterial(conditions);
        //    Connection.Close();
        //}

        //public void UpdateInsertProcMaterial(List<CuttingCondition> cond)
        //{
        //    int newMatId = FindNewElementId("mat_id", "insert_materials");

        //    foreach (var c in cond)
        //    {
        //        Command.CommandText = "INSERT INTO proc_insert_mat (insert_mat_id, proc_mat_id, cut_speed, cut_feed, cut_depth) " +
        //                              "VALUES (@newMatId, @procMat, @speed, @feed, @depth)";
        //        Command.Parameters.AddWithValue("@newMatId", newMatId);
        //        Command.Parameters.AddWithValue("@procMat", c.MaterialId);
        //        Command.Parameters.AddWithValue("@speed", c.CutSpeed);
        //        Command.Parameters.AddWithValue("@feed", c.CutFeed);
        //        Command.Parameters.AddWithValue("@depth", c.CutDepth);
        //        Command.ExecuteNonQuery();
        //    }
        //}

        public void UpdateToolMachTypes(List<int> mach_types)
        {
            int newToolID = FindNewElementId("tool_id", "tools");

            foreach (var type in mach_types)
            {
                Command.CommandText = "INSERT INTO tools (tool_id, operation_id) VALUES (@tool_id, @operation_id)";
                Command.Parameters.AddWithValue("@tool_id", newToolID);
                Command.Parameters.AddWithValue("@operation_id", type);
                Command.ExecuteNonQuery();
            }
        }
        public int FindNewElementId(string element, string tableName)
        {
            Command.CommandText = $"SELECT {element} FROM {tableName} ORDER BY {element} DESC LIMIT 1";

            int newElem = 0;
            var reader = Command.ExecuteReader();
            if (reader.Read())
            {
                newElem = reader.GetInt32(0);
                reader.Close();
            }
            return newElem;
        }

        public Dictionary<int, string> SelectCI()
        {
            return SelectItemIdAndName("ci_id", "ci_name", "ci");
        }

        public Dictionary<int, string> SelectCompliance()
        {
            return SelectItemIdAndName("compliance_id", "compliance_name", "compliance");
        }

        public Dictionary<int, string> SelectCustomers()
        {
            return SelectItemIdAndName("customer_id", "customer_name", "customers");
        }

        public Dictionary<int, string> SelectDepartment()
        {
            return SelectItemIdAndName("department_id", "department_name", "department");
        }

        public Dictionary<int, string> SelectDocuments()
        {
            return SelectItemIdAndName("documents_id", "documents_name", "documents");
        }


        public Dictionary<int, string> SelectМaterials()
        {
            return SelectItemIdAndName("material_cod", "material_name", "materials");
        }


        public Dictionary<int, string> SelectOperation()
        {
            return SelectItemIdAndName("operation_id", "operation_name", "operation");
        }


        public Dictionary<int, string> SelectOrders()
        {
            return SelectItemIdAndName("orders_id", "orders_name", "orders");
        }


        public Dictionary<int, string> SelectProduct()
        {
            return SelectItemIdAndName("product_id_SAP", "product_name", "products");
        }


        public Dictionary<int, string> SelectSpecialty()
        {
            return SelectItemIdAndName("specialty_id", "specialty_name", "specialty");
        }



        public Dictionary<int, string> SelectStatus()
        {
            return SelectItemIdAndName("status_id", "status_name", "status");
        }





        private Dictionary<int, string> SelectItemIdAndName(string idField, string nameField, string tableName)
        {
            var dict = new Dictionary<int, string>();
            Command.CommandText = $"SELECT {idField}, {nameField} FROM {tableName}";
            Connection.Open();
            var reader = Command.ExecuteReader();
            while (reader.Read())
            {
                dict.Add(reader.GetInt32(0), reader.GetString(1));
            }
            reader.Close();
            Connection.Close();
            return dict;
        }

        //public List<ToolComplexResult> SelectToolByMachType(int procMaterial, int machType, int quality)
        //{
        //    List<ToolComplexResult> result = new List<ToolComplexResult>();

        //    Command.CommandText = "SELECT tools.tool_name, tools.tool_hold_size, inserts.insert_full_name, inserts_type.type_size, inserts_mach_quality.quality_code, " +
        //                          "insert_materials.mat_name, proc_insert_mat.cut_speed, proc_insert_mat.cut_feed, proc_insert_mat.cut_depth " +
        //                          "FROM proc_materials INNER JOIN(insert_materials INNER JOIN proc_insert_mat ON insert_materials.mat_id = proc_insert_mat.insert_mat_id) " +
        //                          "ON proc_materials.proc_mat_id = proc_insert_mat.proc_mat_id, " +
        //                          "(inserts_mach_quality INNER JOIN((inserts_type INNER JOIN inserts ON inserts_type.[type_id] = inserts.[insert_id]) " +
        //                          "INNER JOIN tools ON inserts_type.[type_id] = tools.[tool_insert_type]) ON inserts_mach_quality.quality_id = inserts.insert_mach_quality) " +
        //                          "INNER JOIN(mach_type INNER JOIN tool_mach_types ON mach_type.mach_id = tool_mach_types.mach_id) ON tools.tool_id = tool_mach_types.tool_id " +
        //                          $"WHERE(((proc_materials.proc_mat_id) = {procMaterial}) AND((inserts_mach_quality.quality_id) = {quality}) AND((mach_type.mach_id) = {machType}))";
        //    Connection.Open();
        //    var rdr = Command.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        result.Add(new ToolComplexResult(rdr.GetString(0), rdr.GetInt32(1), rdr.GetString(2),
        //                                        rdr.GetString(3), rdr.GetString(4), rdr.GetString(5),
        //                                        rdr.GetString(6), rdr.GetString(7), rdr.GetString(8)));
        //    }
        //    rdr.Close();
        //    Connection.Close();
        //    return result;
        //}






        public List<ToolResult> SelectAllTools()
        {
            var result = new List<ToolResult>();

            Command.CommandText = "SELECT tools.tool_name, tools.tool_cod, operation.operation_name " +
                                  "FROM tools INNER JOIN operation ON operation.operation_id = tools.operation_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new ToolResult(rdr.GetString(0), rdr.GetInt32(1), rdr.GetString(2)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }



        public List<MaterialResult> SelectAllMaterials()
        {
            var result = new List<MaterialResult>();

            Command.CommandText = "SELECT materials.material_name, materials.material_cod, CI.ci_name " +
                                  "FROM materials INNER JOIN CI ON CI.ci_id = materials.ci_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new MaterialResult(rdr.GetString(0), rdr.GetInt32(1), rdr.GetString(2)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }

        public List<EquipmentResult> SelectAllEquipment()
        {
            var result = new List<EquipmentResult>();

            Command.CommandText = "SELECT equipment.equipment_id, equipment.equipment_mode, equipment.equipment_name, department.department_name,  operation.operation_name " +
                                  "FROM department INNER JOIN(equipment INNER JOIN operation ON equipment.operation_name = operation.operation_id)" +
                                  " ON equipment.department_name = idepartment.department_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new EquipmentResult(rdr.GetString(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }

        public List<ReportResult> SelectAllReport()
        {
            var result = new List<ReportResult>();

            Command.CommandText = "SELECT report.report_number, report.report_name, department.department_name, specialty.specialty_id" +
                                  "FROM report INNER JOIN(specialty INNER JOIN operation ON equipment.operation_name = operation.operation_id)" +
                                  " ON equipment.department_name = idepartment.department_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new ReportResult(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
    }
}
