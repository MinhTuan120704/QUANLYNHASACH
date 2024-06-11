﻿using BLL.IServices;
using BLL.Services;
using DAL.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for BillPage.xaml
    /// </summary>
    public partial class BillPage : Page
    {
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        private static OrderService orderService;

        private static BookService bookService;

        private void LoadOrders()
        {
            orderService = new OrderService();
            Orders = new ObservableCollection<Order>(orderService.GetAllOrder());
            OrdersListView.ItemsSource = Orders;
        }
        private void LoadBooks()
        {
            bookService = new BookService();
            Books = new ObservableCollection<Book>(bookService.GetAllBook());
        }
        public BillPage()
        {
            InitializeComponent();
            orderService = new OrderService();
            LoadOrders();
        }
        private void event_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void event_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage newPage = new MainPage();


            this.NavigationService.Navigate(newPage);
        }

        private bool isAdminBorderVisible = false;
        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdminBorderVisible)
            {
                adminBorder.Visibility = Visibility.Visible;
                isAdminBorderVisible = true;
            }
            else
            {
                adminBorder.Visibility = Visibility.Hidden;
                isAdminBorderVisible = false;
            }
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage newPage = new SettingPage();
            this.NavigationService.Navigate(newPage);
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage newPage = new LoginPage();
            this.NavigationService.Navigate(newPage);
        }

        private void CTHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ThemHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            addOrderBorder.Visibility = Visibility.Visible;
        }

        private void closeBorder_addOrder(object sender, RoutedEventArgs e)
        {
            TextName.Text = "";
            PhoneText.Text = "";
            addOrderBorder.Visibility = Visibility.Hidden;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
