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
    /// Логика взаимодействия для PageBlacklist.xaml
    /// </summary>
    public partial class PageBlacklist : Page
    {
        public PageBlacklist()
        {
            InitializeComponent();

            try
            {
                dgBlackList.ItemsSource = AdminToolEntities.GetContext().Blacklist.ToList();
            }
            catch
            {
                MessageBox.Show("Случилась непредвиденная ошибка связанная с базой данных", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            Whitelist whitelistPlayer = new Whitelist();
            Blacklist blacklistPlayer = new Blacklist();

            blacklistPlayer = dgBlackList.SelectedItem as Blacklist;

            if (MessageBox.Show($"Вы действительно хотите разблокировать {blacklistPlayer.PlayerNickname}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                whitelistPlayer.PlayerNickname = blacklistPlayer.PlayerNickname;
                whitelistPlayer.Steam64 = blacklistPlayer.Steam64;
                DateTime thisDay = DateTime.Now;
                whitelistPlayer.RegistrationDate = thisDay;

                AdminToolEntities.GetContext().Whitelist.Add(whitelistPlayer);
                AdminToolEntities.GetContext().Blacklist.Remove(blacklistPlayer);
                Library.DatabaseManager.DatabaseEntry();
                MessageBox.Show("Пользователь был разблокирован", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                dgBlackList.ItemsSource = AdminToolEntities.GetContext().Blacklist.ToList();
            }
        }
    

        private void btnChangeData_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaBlacklistAddPlayer((sender as Button).DataContext as Blacklist));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AdminToolEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgBlackList.ItemsSource = AdminToolEntities.GetContext().Blacklist.ToList();
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
                from nickname in data.Blacklist
                where nickname.PlayerNickname == tbSearch.Text
                select new
                {
                    nickname.PlayerID,
                    nickname.PlayerNickname,
                    nickname.Steam64
                };

                dgBlackList.ItemsSource = query.ToList();

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
                from steam64 in data.Blacklist
                where steam64.Steam64 == tbSearch.Text
                select new
                {
                    steam64.PlayerID,
                    steam64.PlayerNickname,
                    steam64.Steam64
                };

                dgBlackList.ItemsSource = query.ToList();

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
