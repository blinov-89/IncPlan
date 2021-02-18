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
    /// Логика взаимодействия для CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        public CustomersWindow()
        {
            InitializeComponent();
        }

        private void AddNewCustomersEvent(object sender, RoutedEventArgs e)
        {
            if (customersNameField.Text.Length == 0)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var customer = new Сustomer(customersNameField.Text);
            MainWindow.sqlDB.AddNewCustomer(customer);
            MessageBox.Show("Новый заказчик добавлен", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
