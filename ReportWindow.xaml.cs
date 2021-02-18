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
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            reportDepField.ItemsSource = MainWindow.sqlDB.SelectDepartment();
            reportSpecField.ItemsSource = MainWindow.sqlDB.SelectSpecialty();
        }

        private void AddNewReportEvent(object sender, RoutedEventArgs e)
        {
            if (reportNameField.Text.Length == 0 || reportDepField.SelectedItem == null || reportSpecField.SelectedItem == null)
            {
                MainWindow.ShowEmptyFieldError();
                return;
            }
            var selectDepartment = (KeyValuePair<int, string>)(reportDepField.SelectedItem);
            var DepId = selectDepartment.Key;
            var selectSpecialty = (KeyValuePair<int, string>)(reportSpecField.SelectedItem);
            var SpecId = selectSpecialty.Key;
            var report = new Report(reportNumberField.Text, reportNameField.Text, DepId, SpecId);
            MainWindow.sqlDB.AddNewReport(report);
            MessageBox.Show("Сотрудник добавлен в справочник", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
