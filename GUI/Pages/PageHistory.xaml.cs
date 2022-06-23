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
using AdminTool.Data;

namespace AdminTool.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageHistory.xaml
    /// </summary>
    public partial class PageHistory : Page
    {
        public PageHistory()
        {
            InitializeComponent();

            try
            {
                dgHistory.ItemsSource = AdminToolEntities.GetContext().History.ToList();
            }
            catch
            {
                MessageBox.Show("Случилась непредвиденная ошибка связанная с базой данных", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AdminToolEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgHistory.ItemsSource = AdminToolEntities.GetContext().History.ToList();
            }
        }
    }
}
