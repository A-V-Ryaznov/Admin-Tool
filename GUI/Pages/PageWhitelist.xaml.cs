using AdminTool.Data;
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

namespace AdminTool.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageWhitelist.xaml
    /// </summary>
    public partial class PageWhitelist : Page
    {
        public PageWhitelist()
        {
            InitializeComponent();

            try
            {
                dgWhiteList.ItemsSource = AdminToolEntities.GetContext().Player.ToList();
            }
            catch
            {
                MessageBox.Show("Случилась непредвиденная ошибка связанная с базой данных", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClickOnMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Я работаю", "Оно живое");
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaWhitelistAddPlayer());
        }

        private void btnStartSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AdminToolEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgWhiteList.ItemsSource = AdminToolEntities.GetContext().Player.ToList();
            }
        }
    }
}
