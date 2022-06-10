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
    /// Логика взаимодействия для PageStatisticsGeneral.xaml
    /// </summary>
    public partial class PageStatisticsGeneral : Page
    {
        public PageStatisticsGeneral()
        {
            InitializeComponent();

            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsGeneral());
            Library.PageManager.StatisticsFrame = StatisticsFrame;

        }

        private void btnGeneralStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsGeneral());

            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration textDecoration = new TextDecoration();
            textDecoration.Pen = new Pen(Brushes.Transparent, 2);
            textDecoration.Location = TextDecorationLocation.Underline;

            myCollection.Add(textDecoration);
            tblPlayersStatistics.TextDecorations = myCollection;
            tblOnlineStatistics.TextDecorations = myCollection;
            tblAdministrationStatistics.TextDecorations = myCollection;

            tblGeneralStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnPlayersStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsPlayers());




            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration textDecoration = new TextDecoration();
            textDecoration.Pen = new Pen(Brushes.Transparent, 2);
            textDecoration.Location = TextDecorationLocation.Underline;

            myCollection.Add(textDecoration);

            tblGeneralStatistics.TextDecorations = myCollection;
            tblOnlineStatistics.TextDecorations = myCollection;
            tblAdministrationStatistics.TextDecorations = myCollection;

            tblPlayersStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnOnlineStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsOnline());

            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration textDecoration = new TextDecoration();
            textDecoration.Pen = new Pen(Brushes.Transparent, 2);
            textDecoration.Location = TextDecorationLocation.Underline;

            myCollection.Add(textDecoration);

            tblGeneralStatistics.TextDecorations = myCollection;
            tblPlayersStatistics.TextDecorations = myCollection;
            tblAdministrationStatistics.TextDecorations = myCollection;

            tblOnlineStatistics.TextDecorations = TextDecorations.Underline;
        }

        private void btnAdministrationStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsFrame.Navigate(new GUI.Pages.Statistics.PageStatisticsAdministrators());

            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration textDecoration = new TextDecoration();
            textDecoration.Pen = new Pen(Brushes.Transparent, 2);
            textDecoration.Location = TextDecorationLocation.Underline;

            myCollection.Add(textDecoration);

            tblGeneralStatistics.TextDecorations = myCollection;
            tblPlayersStatistics.TextDecorations = myCollection;
            tblOnlineStatistics.TextDecorations = myCollection;

            tblAdministrationStatistics.TextDecorations = TextDecorations.Underline;
        }
    }
}
