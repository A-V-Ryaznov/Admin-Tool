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

namespace AdminTool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //this.Visibility = Visibility.Hidden;

            //GUI.Frame.WindowAuthorization windowAuthorization = new GUI.Frame.WindowAuthorization();
            //windowAuthorization.Show();

            MainFrame.Navigate(new GUI.Pages.PageGreeting());
            Library.PageManager.MainFrame = MainFrame;
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageStatisticsGeneral());
        }

        private void btnWhiteList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageWhitelist());
        }

        private void btnBlackList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageBlacklist());
        }

        private void btnModeratorList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageModeratorlist());
        }

        private void btnOnlineList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageOnline());
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageHistory());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            GUI.Frame.WindowAuthorization windowAuthorization = new GUI.Frame.WindowAuthorization();
            windowAuthorization.Show();
            this.Close();
        }

        private void btnExpandWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            btnExpandWindow.Visibility = Visibility.Hidden;
            btnStandartSizeWindow.Visibility = Visibility.Visible;
        }

        private void btnСloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRollUpWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnStandartSizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;

            btnStandartSizeWindow.Visibility = Visibility.Hidden;
            btnExpandWindow.Visibility = Visibility.Visible;
        }

        //Перетаскивать окно
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }

    }
}
