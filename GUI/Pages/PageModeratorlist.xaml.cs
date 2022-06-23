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
        //Обработка поиска по имени
        private void btnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            btnSearchByName.Visibility = Visibility.Hidden;
            tbSearch.Clear();
            btnSearchBySteam64.Visibility = Visibility.Visible;
        }
        //Обработка поиска по steam64
        private void btnSearchBySteam64_Click(object sender, RoutedEventArgs e)
        {
            btnSearchBySteam64.Visibility = Visibility.Hidden;
            tbSearch.Clear();
            btnSearchByName.Visibility = Visibility.Visible;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var data = AdminToolEntities.GetContext();

            if (btnSearchByName.Visibility == Visibility.Visible)
            {
                var query =
                from nickname in data.ModeratorList
                where nickname.LastName == tbSearch.Text
                select new
                {
                    nickname.ModeratorID,
                    nickname.LastName,
                    nickname.Steam64
                };

                dgModeratorlist.ItemsSource = query.ToList();

                if (string.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    MessageBox.Show("Поиск не может быть осуществлен, потому что не указано имя игрока", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (query.ToList().Count < 1)
                {
                    MessageBox.Show("Игрок с таким именем не был найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (btnSearchBySteam64.Visibility == Visibility.Visible)
            {
                var query =
                from steam64 in data.ModeratorList
                where steam64.LastName == tbSearch.Text
                select new
                {
                    steam64.ModeratorID,
                    steam64.LastName,
                    steam64.Steam64
                };

                dgModeratorlist.ItemsSource = query.ToList();

                if (string.IsNullOrWhiteSpace(tbSearch.Text))
                {
                    MessageBox.Show("Поиск не может быть осуществлен, потому что не указан Steam64", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (query.ToList().Count < 1)
                {
                    MessageBox.Show("Игрок с таким именем не был найден", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
