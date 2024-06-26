﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Đặt trạng thái cửa sổ khi khởi động
            this.WindowState = WindowState.Maximized;
            MainFrame.Content = new LoginPage();
            //HideTitleBar();
        }

        public void HideTitleBar()
        {
            this.WindowStyle = WindowStyle.None;
        }
    }

    public static class GlobalVariables
    {
        public static string UserText { get; set; }
    }

}