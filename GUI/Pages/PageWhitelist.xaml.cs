using AdminTool.Data;
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
                dgWhiteList.ItemsSource = AdminToolEntities.GetContext().Whitelist.ToList();
            }
            catch
            {
                MessageBox.Show("Случилась непредвиденная ошибка связанная с базой данных", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaWhitelistAddPlayer(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AdminToolEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgWhiteList.ItemsSource = AdminToolEntities.GetContext().Whitelist.ToList();
            }
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            Whitelist whitelistPlayer = new Whitelist();
            Blacklist blacklistPlayer = new Blacklist();

            whitelistPlayer = dgWhiteList.SelectedItem as Whitelist;

            if (MessageBox.Show($"Вы действительно хотите заблокировать {whitelistPlayer.PlayerNickname}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    blacklistPlayer.PlayerNickname = whitelistPlayer.PlayerNickname;
                    blacklistPlayer.Steam64 = whitelistPlayer.Steam64;
                    blacklistPlayer.ReasonForBlocking = "Введите причину";
                    DateTime thisDay = DateTime.Today;
                    blacklistPlayer.DateTimeBanned = thisDay;

                    AdminToolEntities.GetContext().Blacklist.Add(blacklistPlayer);
                    AdminToolEntities.GetContext().Whitelist.Remove(whitelistPlayer);
                    AdminToolEntities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь был перемещен в черный список","Результат",MessageBoxButton.OK, MessageBoxImage.Information);
                    dgWhiteList.ItemsSource = AdminToolEntities.GetContext().Whitelist.ToList();
                }
                catch(DbEntityValidationException ex)
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
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.WorkingWithDatabase.PagaWhitelistAddPlayer((sender as Button).DataContext as Whitelist));
        }
    }
}
