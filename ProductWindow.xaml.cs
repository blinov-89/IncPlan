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
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

        private void AddNewProductEvent(object sender, RoutedEventArgs e)
        {
            if (productNameField.Text.Length == 0 || productIdSAPField.Text.Length == 0 || productTimeField.Text.Length == 0)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var product = new Product(productNameField.Text, int.Parse(productIdSAPField.Text), float.Parse(productTimeField.Text));
            MainWindow.sqlDB.AddNewProduct(product);
            MessageBox.Show("Изделие в справочник добавлено", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
