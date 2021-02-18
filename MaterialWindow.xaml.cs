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
    /// Логика взаимодействия для MaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        public MaterialWindow()
        {
            InitializeComponent();
            materialCiField.ItemsSource = MainWindow.sqlDB.SelectCI();

        }
        private void AddNewMaterialEvent(object sender, RoutedEventArgs e)
        {
            if (materialNameField.Text.Length == 0 || materialCiField.SelectedItem == null)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var selectedCiType = (KeyValuePair<int, string>)materialCiField.SelectedItem;
            var CiId = selectedCiType.Key;
            var material = new Material(materialNameField.Text, int.Parse(materialCodField.Text), CiId);
            MainWindow.sqlDB.AddNewMaterial(material);
            MessageBox.Show("Материал добавлен", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
