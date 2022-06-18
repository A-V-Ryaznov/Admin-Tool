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
    /// Логика взаимодействия для PageStatisticsMain.xaml
    /// </summary>
    public partial class PageStatisticsMain : Page
    {
        public PageStatisticsMain()
        {
            InitializeComponent();

            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsGeneral());
            Library.PageManager.StatisticsFrame = StatisticsFrame;
        }

        private void btnGeneralStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsGeneral());

            Library.StyleManager.CreateUnderline();


            tblPlayersStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblOnlineStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblAdministrationStatistics.TextDecorations = Library.StyleManager.CreateUnderline();

            tblGeneralStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnPlayersStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsPlayers());

            tblGeneralStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblOnlineStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblAdministrationStatistics.TextDecorations = Library.StyleManager.CreateUnderline();

            tblPlayersStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnOnlineStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsOnline());

            tblGeneralStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblPlayersStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblAdministrationStatistics.TextDecorations = Library.StyleManager.CreateUnderline();

            tblOnlineStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnAdministrationStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsAdministrators());

            tblGeneralStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblPlayersStatistics.TextDecorations = Library.StyleManager.CreateUnderline();
            tblOnlineStatistics.TextDecorations = Library.StyleManager.CreateUnderline();

            tblAdministrationStatistics.TextDecorations = TextDecorations.Underline;
        }
    }
}
