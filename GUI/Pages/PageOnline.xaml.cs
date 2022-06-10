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
            MessageBox.Show("Текущее количество игроков: " + tbCountingOnline.Text, "Потдверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
        }
    }
}
