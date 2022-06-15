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

namespace AdminTool.GUI.Frame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new GUI.Pages.PageGreeting());
            Library.PageManager.MainFrame = MainFrame;
        }
        //Обработка событий

        //Кнопка для перехода в белый список
        private void btnWhiteList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageWhitelist());

            tblWhiteList.TextDecorations = TextDecorations.Underline;
            tblBlackList.TextDecorations = Library.StyleManager.CreateUnderline();
            tblModeratorList.TextDecorations = Library.StyleManager.CreateUnderline();
        }
        //Кнопка для перехода в черный список
        private void btnBlackList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageBlacklist());

            tblBlackList.TextDecorations = TextDecorations.Underline;

            tblWhiteList.TextDecorations = Library.StyleManager.CreateUnderline();
            tblModeratorList.TextDecorations = Library.StyleManager.CreateUnderline();
        }
        //Кнопка для перехода на список модераторов
        private void btnModeratorList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GUI.Pages.PageModeratorlist());

            tblModeratorList.TextDecorations = TextDecorations.Underline;

            tblWhiteList.TextDecorations = Library.StyleManager.CreateUnderline();
            tblBlackList.TextDecorations = Library.StyleManager.CreateUnderline();
        }
        //Кнопка для выхода из аккунта
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            GUI.Frame.WindowAuthorization windowAuthorization = new GUI.Frame.WindowAuthorization();
            windowAuthorization.Show();
            this.Close();
        }
        //Кнопки для работы с окном и приложением
        //Свернуть окно
        private void btnRollUpWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Развернуть окно
        private void btnExpandWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            btnExpandWindow.Visibility = Visibility.Hidden;
            btnStandartSizeWindow.Visibility = Visibility.Visible;
        }
        //Вернуть окно в стандартный размер
        private void btnStandartSizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;

            btnStandartSizeWindow.Visibility = Visibility.Hidden;
            btnExpandWindow.Visibility = Visibility.Visible;
        }
        //Закрыть окно
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
