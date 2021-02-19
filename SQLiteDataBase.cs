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
            Command.CommandText = "INSERT INTO materials (material_name, material_cod, ci_id) VALUES (@name, @cod, @ci)";
            Command.Parameters.AddWithValue("@name", material.MaterialName);
            Command.Parameters.AddWithValue("@cod", material.MaterialCod);
            Command.Parameters.AddWithValue("@ci", material.CiId);
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public void AddNewCustomer(Сustomer customers)
        {
            Connection.Open();
            Command.CommandText = "INSERT INTO customers (customer_name) VALUES (@name)";
            Command.Parameters.AddWithValue("@name", customers.СustomerName);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void AddNewOrder(Orders order)
        {
            Connection.Open();
            Command.CommandText = "INSERT INTO orders (orders_name) VALUES (@name)";
            Command.Parameters.AddWithValue("@name", order.OrdersName);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void AddNewReport(Report report)
        {
            Connection.Open();
            Command.CommandText = "INSERT INTO report (report_number, report_name, department_id, specialty_id) VALUES (@number, @name, @depart, @spec)";
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
            Command.CommandText = "INSERT INTO products (product_name, product_id_SAP, product_time) VALUES (@name, @idSAP, @time)";
            Command.Parameters.AddWithValue("@name", product.ProductName);
            Command.Parameters.AddWithValue("@idSAP", product.ProductIdSAP);
            Command.Parameters.AddWithValue("@time", product.ProductTime);
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public void AddNewPlan(Plan plan)
        {
            Connection.Open();
            Command.CommandText = "INSERT INTO plan (plan_quantity, product_id_SAP, orders_id, customer_id, " +
                "report_id, status_id, documents_id) VALUES (@quantity, @product, @orders, @customer, " +
                "@report, @status, @documents)";
            Command.Parameters.AddWithValue("@quantity", plan.PlanQuantity);
            Command.Parameters.AddWithValue("@product", plan.ProductIdSAP);
            Command.Parameters.AddWithValue("@orders", plan.OrdersId);
            Command.Parameters.AddWithValue("@customer", plan.CustomerId);
            Command.Parameters.AddWithValue("@report", plan.ReportId);
            Command.Parameters.AddWithValue("@status", plan.StatusId);
            Command.Parameters.AddWithValue("@documents", plan.DocumentsId);
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

        public Dictionary<int, string> SelectReport()
        {
            return SelectItemIdAndName("report_id", "report_name", "report");
        }

        public Dictionary<int, string> SelectTools()
        {
            return SelectItemIdAndName("tool_cod", "tool_name", "tools");
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

            Command.CommandText = "SELECT equipment.equipment_id, equipment.equipment_model, equipment.equipment_name, department.department_name,  operation.operation_name " +
                                  "FROM department INNER JOIN(equipment INNER JOIN operation ON equipment.operation_id = operation.operation_id)" +
                                  " ON equipment.department_id = department.department_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new EquipmentResult(rdr.GetInt32(0), rdr.IsDBNull(1) ? null : rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<ReportResult> SelectAllReport()
        {
            var result = new List<ReportResult>();
           
            Command.CommandText = "SELECT report.report_number, report.report_name, department.department_name, specialty.specialty_name " +
                                  "FROM department INNER JOIN(specialty INNER JOIN report ON specialty.specialty_id = report.specialty_id)" +
                                  " ON department.department_id = report.department_id";
            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new ReportResult(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<string> SelectAllReportList()
        {
            var result = new List<string>();

            Command.CommandText = "SELECT report.report_number, report.report_name, department.department_name, specialty.specialty_name " +
                                  "FROM department INNER JOIN(specialty INNER JOIN report ON specialty.specialty_id = report.specialty_id)" +
                                  " ON department.department_id = report.department_id";
            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                StringBuilder a = new StringBuilder();
                result.Add(a.AppendLine($"" +
                    $"Таб. № {rdr.GetString(0)}, ФИО: {rdr.GetString(1)}, Специальность: {rdr.GetString(3)}").ToString());
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<string> SelectAllEquipmentList()
        {
            var result = new List<string>();

            Command.CommandText = "SELECT equipment.equipment_id, equipment.equipment_model, equipment.equipment_name, department.department_name,  operation.operation_name " +
                                  "FROM department INNER JOIN(equipment INNER JOIN operation ON equipment.operation_id = operation.operation_id)" +
                                  " ON equipment.department_id = department.department_id";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                StringBuilder a = new StringBuilder();
                result.Add(a.AppendLine($"Код: {rdr.GetInt32(0)}, Модель: {(rdr.IsDBNull(1) ? null : rdr.GetString(1))}, Наименование: {rdr.GetString(2)}, {rdr.GetString(3)}").ToString());
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<string> SelectAllPlanList()
        {
            var result = new List<string>();

            Command.CommandText = "SELECT plan.product_id_SAP, products.product_name, plan.plan_quantity, plan.plan_time, orders.orders_name, " +
                                    "customers.customer_name, report.report_name, status.status_name, documents.documents_name " +
                                    "FROM report INNER JOIN(status INNER JOIN(products INNER JOIN(orders " +
                                    "INNER JOIN(documents INNER JOIN(customers INNER JOIN plan ON customers.customer_id = plan.customer_id) " +
                                    "ON documents.documents_id = plan.documents_id) ON orders.orders_id = plan.orders_id) " +
                                    "ON products.product_id_SAP = plan.product_id_SAP) ON status.status_id = plan.status_id) " +
                                    "ON report.report_id = plan.report_id ";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                StringBuilder a = new StringBuilder();
                result.Add(a.AppendLine($"Код: {rdr.GetInt32(0)}, Наименование: {rdr.GetString(1)}, Кол-во: {rdr.GetInt32(2)} шт., Время изг.: {rdr.GetString(3)} н/ч, Заказ: {rdr.GetString(4)}, Заказчик: {rdr.GetString(5)}").ToString());
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<ProductResult> SelectAllProduct()
        {
            var result = new List<ProductResult>();

            Command.CommandText = "SELECT products.product_name, products.product_id_SAP, products.product_time " +
                                  "FROM products";
            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new ProductResult(rdr.GetString(0), rdr.GetInt32(1), rdr.GetFloat(2)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<PlanResult> SelectAllPlan()
        {
            var result = new List<PlanResult>();

            Command.CommandText = "SELECT plan.product_id_SAP, products.product_name, plan.plan_quantity, plan.plan_time, orders.orders_name, " +
                                    "customers.customer_name, report.report_name, status.status_name, documents.documents_name " +
                                    "FROM report INNER JOIN(status INNER JOIN(products INNER JOIN(orders " +
                                    "INNER JOIN(documents INNER JOIN(customers INNER JOIN plan ON customers.customer_id = plan.customer_id) " +
                                    "ON documents.documents_id = plan.documents_id) ON orders.orders_id = plan.orders_id) " +
                                    "ON products.product_id_SAP = plan.product_id_SAP) ON status.status_id = plan.status_id) " +
                                    "ON report.report_id = plan.report_id ";

            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new PlanResult(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3),
                    rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<Сustomer> SelectAllCustomers()
        {
            var result = new List<Сustomer>();

            Command.CommandText = "SELECT customers.customer_name " +
                                  "FROM customers";
            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new Сustomer(rdr.GetString(0)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
        public List<Orders> SelectAllOrders()
        {
            var result = new List<Orders>();

            Command.CommandText = "SELECT orders.orders_name " +
                                  "FROM orders";
            Connection.Open();
            var rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new Orders(rdr.GetString(0)));
            }
            rdr.Close();
            Connection.Close();
            return result;
        }
    }
}
