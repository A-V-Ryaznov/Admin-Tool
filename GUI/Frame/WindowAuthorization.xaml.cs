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
using System.Windows.Shapes;
using AdminTool;

namespace AdminTool.GUI.Frame
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
            
        }

        private void btnaAthorization_Click(object sender, RoutedEventArgs e)
        {
            
            AdminTool.MainWindow mainWindow = new MainWindow();

            //this.Owner = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        private void cbShowPassword_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (cbShowPassword.IsChecked.Value == true)
            {
                tbPassword.Text = pbPassword.Password;
                tbPassword.Visibility = Visibility.Visible;
                pbPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                pbPassword.Password = tbPassword.Text;
                tbPassword.Visibility = Visibility.Hidden;
                pbPassword.Visibility = Visibility.Visible;
            }
        }

        private void btnСloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRollUpWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Перетаскивать окно
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
