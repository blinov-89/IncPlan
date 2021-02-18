using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace IncPlan
{
    /// <summary>
    /// Логика взаимодействия для PlanWindow.xaml
    /// </summary>
    public partial class PlanWindow : Window
    {
        public PlanWindow()
        {
            InitializeComponent();
            productName.ItemsSource = MainWindow.sqlDB.SelectProduct();
            ordersId.ItemsSource = MainWindow.sqlDB.SelectOrders();
            customerId.ItemsSource = MainWindow.sqlDB.SelectCustomers();
            reportId.ItemsSource = MainWindow.sqlDB.SelectReport();
            statusId.ItemsSource = MainWindow.sqlDB.SelectStatus();
            documentId.ItemsSource = MainWindow.sqlDB.SelectDocuments();
        }

        private void AddNewPlanEvent(object sender, RoutedEventArgs e)
        {
            if (planQuantityField.Text.Length == 0 || productName.SelectedItem == null || 
                ordersId.SelectedItem == null || customerId.SelectedItem == null ||
                reportId.SelectedItem == null || statusId.SelectedItem == null || documentId.SelectedItem == null)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var selectProduct = (KeyValuePair<int, string>)(productName.SelectedItem);
            var ProdId = selectProduct.Key;
            var selectOrders = (KeyValuePair<int, string>)(ordersId.SelectedItem);
            var OrdersId = selectOrders.Key;
            var selectCustomers = (KeyValuePair<int, string>)(customerId.SelectedItem);
            var CustomId = selectCustomers.Key;
            var selectReport = (KeyValuePair<int, string>)(reportId.SelectedItem);
            var RepId = selectReport.Key;
            var selectStatus = (KeyValuePair<int, string>)(statusId.SelectedItem);
            var StatusId = selectStatus.Key;
            var selectDoc = (KeyValuePair<int, string>)(documentId.SelectedItem);
            var DocId = selectDoc.Key;

            var plan = new Plan(int.Parse(planQuantityField.Text), ProdId, OrdersId, CustomId, RepId, StatusId, DocId);
            MainWindow.sqlDB.AddNewPlan(plan);
            MessageBox.Show("Заказ создан", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
