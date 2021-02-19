using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace IncPlan
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SQLiteDataBase sqlDB = new SQLiteDataBase(@"URI=file:" + System.IO.Path.Combine(Environment.CurrentDirectory, "Databaseplan.db"));
        //private List<ReportResult> list;

        public MainWindow()
        {
            InitializeComponent();
            //list = sqlDB.SelectAllReport();
            plan.ItemsSource = sqlDB.SelectAllPlanList();
            operation.ItemsSource = sqlDB.SelectOperation();
            //report.ItemsSource = list.Select(x=> x.ReportName);
            report.ItemsSource = sqlDB.SelectAllReportList();
            //report.ItemsSource = list;
            material.ItemsSource = sqlDB.SelectМaterials();
            tool.ItemsSource = sqlDB.SelectTools();
            tool2.ItemsSource = sqlDB.SelectTools();
            tool3.ItemsSource = sqlDB.SelectTools();
            equipment.ItemsSource = sqlDB.SelectAllEquipmentList();

        }
        // доработать кнопку сохранить sw.WriteLine(      );
        private void Save_Click(object sender, EventArgs args)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = ".txt";
            savefile.Filter = "Text files|*.txt";
            if (savefile.ShowDialog() == savefile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                {
                    sw.WriteLine(baseGrid);
                    sw.Close();
                }
            }

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(baseGrid, "Печать");
            }
        }

        private void Exit_Click(object sender, EventArgs args)
        {
            MenuItem menuItem = (MenuItem)sender;
            Close();
        }

        public static void ShowEmptyFieldError()
        {
            MessageBox.Show("Не заполнены требуемые поля", "Fail!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddNewToolMenuClick(object sender, RoutedEventArgs e)
        {
            ToolWindow newToolW = new ToolWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewMaterialMenuClick(object sender, RoutedEventArgs e)
        {
            MaterialWindow newToolW = new MaterialWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewCustomersMenuClick(object sender, RoutedEventArgs e)
        {
            CustomersWindow newToolW = new CustomersWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewOrdersMenuClick(object sender, RoutedEventArgs e)
        {
            OrdersWindow newToolW = new OrdersWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewProductMenuClick(object sender, RoutedEventArgs e)
        {
            ProductWindow newToolW = new ProductWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewReportMenuClick(object sender, RoutedEventArgs e)
        {
            ReportWindow newToolW = new ReportWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void ShowEquipmentList(object sender, RoutedEventArgs e)
        {
            EquipmentWindow newToolW = new EquipmentWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void AddNewPlanMenuClick(object sender, RoutedEventArgs e)
        {
            PlanWindow newToolW = new PlanWindow();
            newToolW.Owner = this;
            newToolW.Show();
        }
        private void ShowToolMaterialList(object sender, RoutedEventArgs e)
        {
            ToolMaterialListWindow tiListW = new ToolMaterialListWindow();
            tiListW.Owner = this;
            tiListW.Show();
        }
        private void ShowReportList(object sender, RoutedEventArgs e)
        {
            ReportListWindow rListW = new ReportListWindow();
            rListW.Owner = this;
            rListW.Show();
        }
        private void ShowProductsList(object sender, RoutedEventArgs e)
        {
            ProductListWindow rListW = new ProductListWindow();
            rListW.Owner = this;
            rListW.Show();
        }
        private void ShowPlanList(object sender, RoutedEventArgs e)
        {
            PlanListWindow rListW = new PlanListWindow();
            rListW.Owner = this;
            rListW.Show();
        }

        private void ShowCustomersList(object sender, RoutedEventArgs e)
        {
            CustomersListWindow rListW = new CustomersListWindow();
            rListW.Owner = this;
            rListW.Show();
        }

        private void ShowOrdersList(object sender, RoutedEventArgs e)
        {
            OrdersListWindow rListW = new OrdersListWindow();
            rListW.Owner = this;
            rListW.Show();
        }

        //private void OnReportSelected(object sender, SelectionChangedEventArgs e)
        //{
        //    specialtyName.Text = (list.Where(x => x.ReportName == (sender as ComboBox).SelectedItem.ToString()).First().SpecialtyName).ToString();
        //}
    }
}
