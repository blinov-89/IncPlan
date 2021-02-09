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
        public MainWindow()
        {
            InitializeComponent();
            //procMaterialCase.ItemsSource = sqlDB.SelectProcMaterials();
            //machTypeCase.ItemsSource = sqlDB.SelectOperation();
            //qualityCase.ItemsSource = sqlDB.SelectInsertQuality();
        }
        // добавить кнопки сохранить
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
        private void ShowToolMaterialList(object sender, RoutedEventArgs e)
        {
            ToolMaterialListWindow tiListW = new ToolMaterialListWindow();
            tiListW.Owner = this;
            tiListW.Show();
        }
    }
}
