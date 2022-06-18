using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для PageModeratorlist.xaml
    /// </summary>
    public partial class PageModeratorlist : Page
    {
        public PageModeratorlist()
        {
            InitializeComponent();

            try
            {
                dgModeratorlist.ItemsSource = AdminToolEntities.GetContext().ModeratorList.ToList();
            }
            catch
            {
                MessageBox.Show("Случилась непредвиденная ошибка связанная с базой данных", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            ModeratorList moderator = new ModeratorList();

            moderator = dgModeratorlist.SelectedItem as ModeratorList;

            if (MessageBox.Show($"Вы действительно снять с поста {moderator.LastName}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AdminToolEntities.GetContext().ModeratorList.Remove(moderator);
                Library.DatabaseManager.DatabaseEntry();
                MessageBox.Show("Модератор был снят с должности", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                dgModeratorlist.ItemsSource = AdminToolEntities.GetContext().ModeratorList.ToList();
            }
        }

        private void btnChangeData_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaModeratorlistAddPlayer((sender as Button).DataContext as ModeratorList));
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaModeratorlistAddPlayer(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AdminToolEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgModeratorlist.ItemsSource = AdminToolEntities.GetContext().ModeratorList.ToList();
            }
        }
    }



}
