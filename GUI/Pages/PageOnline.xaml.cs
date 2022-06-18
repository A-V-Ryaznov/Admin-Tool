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

namespace AdminTool.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOnline.xaml
    /// </summary>
    public partial class PageOnline : Page
    {
        public PageOnline()
        {
            InitializeComponent();
        }

        private void btnSaveCountingOnline_Click(object sender, RoutedEventArgs e)
        {
            //проверка данных
            if(Library.DataVerificationManager.CheckValueOnlinePlayer(tbCountingOnline.Text) == false)
            {
                return;
            }
            //запись данных в бд
            if (MessageBox.Show($"Вы действительно хотите записать, то что текущая заполненность составляет: {tbCountingOnline.Text} человек", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Online online = new Online();

                online.PlayerCount = Convert.ToInt32(tbCountingOnline.Text);
                DateTime thisDay = DateTime.Now;
                online.Datatime = thisDay;

                AdminToolEntities.GetContext().Online.Add(online);
                Library.DatabaseManager.DatabaseEntry();
                MessageBox.Show("Информация сохранена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
