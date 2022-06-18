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
                try
                {
                    whitelistPlayer.PlayerNickname = blacklistPlayer.PlayerNickname;
                    whitelistPlayer.Steam64 = blacklistPlayer.Steam64;
                    DateTime thisDay = DateTime.Now;
                    whitelistPlayer.RegistrationDate = thisDay;

                    AdminToolEntities.GetContext().Whitelist.Add(whitelistPlayer);
                    AdminToolEntities.GetContext().Blacklist.Remove(blacklistPlayer);
                    AdminToolEntities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь был разблокирован", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgBlackList.ItemsSource = AdminToolEntities.GetContext().Blacklist.ToList();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage + "");
                        }
                    }
                }
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
    }
}
