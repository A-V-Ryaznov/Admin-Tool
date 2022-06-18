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

namespace AdminTool.GUI.Pages.WorkingWithDatabase
{
    /// <summary>
    /// Логика взаимодействия для PagaWhitelistAddPlayer.xaml
    /// </summary>
    public partial class PagaWhitelistAddPlayer : Page
    {
        //Создаем объект класса, который позволит произвести запись.
        private Whitelist _currentPlayer = new Whitelist();
        public PagaWhitelistAddPlayer(Whitelist selectedPlayer)
        {
            InitializeComponent();

            if (selectedPlayer != null)
            {
                _currentPlayer = selectedPlayer;
            }

            DataContext = _currentPlayer;
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {

            if (Library.DataVerificationManager.CheckValueTransferToDatabaseWhiteList(_currentPlayer.PlayerNickname, _currentPlayer.Steam64) == false)
            {
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите записать игрока {_currentPlayer.PlayerNickname}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (_currentPlayer.PlayerID == 0)
                {
                    DateTime thisDay = DateTime.Today;
                    _currentPlayer.RegistrationDate = thisDay;
                    AdminToolEntities.GetContext().Whitelist.Add(_currentPlayer);
                }
                Library.DatabaseManager.DatabaseEntry();
                MessageBox.Show("Информация сохранена","Сообщение",MessageBoxButton.OK, MessageBoxImage.Information);
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageWhitelist());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Вы действительно хотите покинуть страницу работы с пользователем? Результаты вашей работы не будут сохранены", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageWhitelist());
            }
            
        }
    }
}
