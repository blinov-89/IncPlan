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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
        }
        private void AddNewOrdersEvent(object sender, RoutedEventArgs e)
        {
            if (ordersNameField.Text.Length == 0)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var orders = new Orders(ordersNameField.Text);
            MainWindow.sqlDB.AddNewOrder(orders);
            MessageBox.Show("Новый заказ добавлен", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
