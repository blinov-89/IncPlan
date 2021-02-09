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
    /// Логика взаимодействия для ToolWindow.xaml
    /// </summary>
    public partial class ToolWindow : Window
    {
        //List<int> machTypes = new List<int>();

        public ToolWindow()
        {
            InitializeComponent();
            toolOpField.ItemsSource = MainWindow.sqlDB.SelectOperation();
  
        }
        //private void ClearMachTypeList(object sender, RoutedEventArgs e)
        //{
        //    machTypes.Clear();
        //    //machTypeListBox.Items.Clear();
        //}

        private void AddNewToolEvent(object sender, RoutedEventArgs e)
        {
            if (toolNameField.Text.Length == 0 || toolOpField.SelectedItem == null)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var selectedOpType = (KeyValuePair<int, string>)toolOpField.SelectedItem;
            var OperId = selectedOpType.Key;
            var tool = new Tool(toolNameField.Text, int.Parse(toolCodField.Text), OperId);
            MainWindow.sqlDB.AddNewTool(tool);
            MessageBox.Show("Инструмент добавлен", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToolHolderFieldInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
