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
using System.Windows.Forms.DataVisualization.Charting;

namespace AdminTool.GUI.Pages.Statistics
{
    /// <summary>
    /// Логика взаимодействия для PageStatisticsGeneral.xaml
    /// </summary>
    public partial class PageStatisticsGeneral : Page
    {
        private AdminToolEntities _context = new AdminToolEntities();
        public PageStatisticsGeneral()
        {
            InitializeComponent();

            tblMaximumCountPlayers.Text = $"Вместимость сервера: {Library.SettingManager.MaximumCountPlayers}";
        }
    }
}

