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
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tbCountingOnline.Text))
            {
                error.AppendLine("Вы не задали значение");
            }
            if(tbCountingOnline.Text != null)
            {
                foreach (var number in tbCountingOnline.Text)
                {
                    if (!char.IsDigit(number))
                    {
                        error.AppendLine("Количество игроков заполняется только в числовом формате");
                        break;
                    }
                }

                if(Convert.ToInt32(tbCountingOnline.Text) > 48 || Convert.ToInt32(tbCountingOnline.Text) < 0)
                {
                    error.AppendLine("Максимальное количество игроков на сервере = 48. Минимальное = 0");
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите записать, то что текущая заполненность составляет: {tbCountingOnline.Text} человек", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Online online = new Online();

                    online.PlayerCount = Convert.ToInt32(tbCountingOnline.Text);
                    DateTime thisDay = DateTime.Now;
                    online.Datatime = thisDay;

                    AdminToolEntities.GetContext().Online.Add(online);
                    AdminToolEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
