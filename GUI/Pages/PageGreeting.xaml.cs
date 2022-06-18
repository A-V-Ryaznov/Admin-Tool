﻿using System;
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
    /// Логика взаимодействия для PageGreeting.xaml
    /// </summary>
    public partial class PageGreeting : Page
    {
        public PageGreeting()
        {
            InitializeComponent();
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            tblGreeting.Text = $"Добро пожаловать, {Library.UserManager.UserFirstName} {Library.UserManager.UserLastName}";
        }
    }
}