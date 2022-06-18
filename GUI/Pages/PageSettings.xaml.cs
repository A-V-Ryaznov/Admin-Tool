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
    /// Логика взаимодействия для PageSettings.xaml
    /// </summary>
    public partial class PageSettings : Page
    {
        public PageSettings()
        {
            InitializeComponent();
        }

        //Сохраняем изменения в настройках
        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (Library.DataVerificationManager.CheckValueMaximumServerPlayer(tbMaximumCountPlayers.Text) == false)
            {
                return;
            }

            Library.SettingManager.MaximumCountPlayers = Convert.ToInt32(tbMaximumCountPlayers.Text);
            MessageBox.Show($"Максимальное количество игроков на сервере теперь составляет {Library.SettingManager.MaximumCountPlayers}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
               
            Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageSettings());
            
        }
        //Сбрасываем все изменения
        private void btnBackSettings_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы действительно хотите вернуть настройки до стандартных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Library.SettingManager.ReturnToStandard();
                MessageBox.Show($"Настройки были возвращены в стандартное значение", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Library.PageManager.MainFrame.Navigate(new GUI.Pages.PageSettings());
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            tbMaximumCountPlayers.Text = Convert.ToString(Library.SettingManager.MaximumCountPlayers);
        }
    }
}
