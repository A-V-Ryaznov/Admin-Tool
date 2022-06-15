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
        private Player _currentPlayer = new Player();
        public PagaWhitelistAddPlayer()
        {
            InitializeComponent();

            DataContext = _currentPlayer;

            cbUserСheckedQuent.ItemsSource = AdminToolEntities.GetContext().User.ToList();
            cbUserConductedInterview.ItemsSource = AdminToolEntities.GetContext().User.ToList();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPlayer.PlayerNickname))
            {
                error.AppendLine("Укажите имя пользователя");
            }
            if (_currentPlayer.Steam64.Length > 17 || _currentPlayer.Steam64.Length < 17)
            {
                error.AppendLine("Steam64 должен быть равен 17 символам");
            }
            
            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if(_currentPlayer.PlayerID == 0)
            {
                _currentPlayer.IdUserAddedSystem = 1;
                _currentPlayer.IdUserConductedInterview = 1;
                _currentPlayer.IdUserСheckedQuent = 1;
                _currentPlayer.IsBanned = false;
                AdminToolEntities.GetContext().Player.Add(_currentPlayer);
            }
            try
            {
                AdminToolEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageWhitelist());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageWhitelist());
        }
    }
}
