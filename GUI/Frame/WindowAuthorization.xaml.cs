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
using AdminTool.Data;

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
        //Обработка событий
        //Видомость пароля
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
        //Авторизация в системе и сверка данных пользователя
        private void btnaAthorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in AdminToolEntities.GetContext().User)
                {
                    if (item.Username.Trim() == tbUsername.Text.Trim())
                    {

                        if (tbPassword.Text.Trim() == item.Password.Trim() || pbPassword.Password.Trim() == item.Password.Trim())
                        {
                            AdminTool.GUI.Frame.MainWindow mainWindow = new MainWindow();
                            Library.UserManager.UserFirstName = item.FirstName.Trim();
                            Library.UserManager.UserLastName = item.LastName.Trim();

                            mainWindow.Show();
                            this.Close();
                        }
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            
        }

        //Работа с окном
        //Кнопка свернуть
        private void btnRollUpWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Кнопка закрыть
        private void btnСloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Перетаскивать окно
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
