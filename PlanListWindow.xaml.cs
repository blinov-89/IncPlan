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
    /// Логика взаимодействия для PlanListWindow.xaml
    /// </summary>
    public partial class PlanListWindow : Window
    {
        public PlanListWindow()
        {
            InitializeComponent();
            AvPlanGrid.ItemsSource = MainWindow.sqlDB.SelectAllPlan();

        }
    }
}
