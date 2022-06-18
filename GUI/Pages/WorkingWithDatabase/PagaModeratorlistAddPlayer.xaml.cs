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

namespace AdminTool.GUI.Pages.WorkingWithDatabase
{
    /// <summary>
    /// Логика взаимодействия для PagaModeratorlistAddPlayer.xaml
    /// </summary>
    public partial class PagaModeratorlistAddPlayer : Page
    {
        private ModeratorList _currentPlayer = new ModeratorList();
        public PagaModeratorlistAddPlayer(ModeratorList selectedPlayer)
        {
            InitializeComponent();

            if (selectedPlayer != null)
            {
                _currentPlayer = selectedPlayer;

                tblAppointmentDate.Text = _currentPlayer.AppointmentDate.ToString();
            }

            DataContext = _currentPlayer;
        }
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            if (Library.DataVerificationManager.CheckValueTransferToDatabaseModeratorList(_currentPlayer.FirstName, _currentPlayer.LastName, _currentPlayer.Steam64) == false)
            {
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите записать игрока {_currentPlayer.LastName}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (_currentPlayer.ModeratorID == 0)
                {
                    DateTime thisDay = DateTime.UtcNow;
                    _currentPlayer.AppointmentDate = thisDay;
                    AdminToolEntities.GetContext().ModeratorList.Add(_currentPlayer);
                }

                Library.DatabaseManager.DatabaseEntry();
                MessageBox.Show("Информация сохранена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageModeratorlist());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы действительно хотите покинуть страницу работы с пользователем? Результаты вашей работы не будут сохранены", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageModeratorlist());
            }
        }
    }
}
