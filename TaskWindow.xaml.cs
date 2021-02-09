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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        List<int> machTypes = new List<int>();

        public TaskWindow()
        {
            InitializeComponent();
            nameProductField.ItemsSource = MainWindow.sqlDB.SelectInsertTypes();
            machTypeComboBox.ItemsSource = MainWindow.sqlDB.SelectMachTypes();
        }

        private void AddMachTypeEvent(object sender, RoutedEventArgs e)
        {
            var selectedMachType = (KeyValuePair<int, string>)machTypeComboBox.SelectedItem;
            if (!machTypes.Contains(selectedMachType.Key))
            {
                machTypes.Add(selectedMachType.Key);
                machTypeListBox.Items.Add(selectedMachType.Value);
            }
            else MessageBox.Show("Такой тип обработки уже добавлен", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearMachTypeList(object sender, RoutedEventArgs e)
        {
            machTypes.Clear();
            machTypeListBox.Items.Clear();
        }

        private void AddNewToolEvent(object sender, RoutedEventArgs e)
        {
            if (toolNameField.Text.Length == 0 || toolOpField.SelectedItem == null
            || toolNameField.Text.Length == 0 || machTypeListBox.Items.Count == 0)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var selectedType = (KeyValuePair<int, string>)toolOpField.SelectedItem;
            var insTypeId = selectedType.Key;
            var tool = new Tool(toolNameField.Text, int.Parse(toolCodField.Text), insTypeId, machTypes);
            MainWindow.sqlDB.AddNewTool(tool);
            MessageBox.Show("Державка добавлена", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToolHolderFieldInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void AddNewPZ(object sender, RoutedEventArgs e)
        {

        }
    }
}
