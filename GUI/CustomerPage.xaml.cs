using BLL.IServices;
using BLL.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    

    public partial class CustomerPage : Page
    {

        public CustomerPage()
        {
            InitializeComponent();
            

        }
        private bool isAdminBorderVisible = false;
        private void home_MouseEnter(object sender, MouseEventArgs e)
        {
            home.Cursor = Cursors.Hand;
        }

        private void home_MouseLeave(object sender, MouseEventArgs e)
        {
            home.Cursor = Cursors.Arrow;
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage newPage = new MainPage();


            this.NavigationService.Navigate(newPage);
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            

            filterBorder.Visibility = Visibility.Visible;

        }

        private void filterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void filterButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;

        }

        private void closeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closeButton.Cursor = Cursors.Hand;
        }



        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeButton.Cursor = Cursors.Arrow;
        }



        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage newPage = new LoginPage();
            this.NavigationService.Navigate(newPage);
        }

        private void logOutButton_MouseEnter(object sender, MouseEventArgs e)
        {
            logOutButton.Cursor = Cursors.Hand;
        }

        private void logOutButton_MouseLeave(object sender, MouseEventArgs e)
        {
            logOutButton.Cursor = Cursors.Arrow;
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            SettingPage newPage = new SettingPage();
            this.NavigationService.Navigate(newPage);
        }

        private void settingButton_MouseEnter(object sender, MouseEventArgs e)
        {
            settingButton.Cursor = Cursors.Hand;
        }

        private void settingButton_MouseLeave(object sender, MouseEventArgs e)
        {
            settingButton.Cursor = Cursors.Arrow;
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdminBorderVisible)
            {
                adminBorder.Visibility = Visibility.Visible;
                isAdminBorderVisible = true;
            }
            else
            {
                adminBorder.Visibility = Visibility.Collapsed;
                isAdminBorderVisible = false;
            }
        }

        private void adminButton_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void adminButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void addCustomer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            addCustomerBorder.Visibility = Visibility.Visible;
        }
        private void event_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void event_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            addCustomerBorder.Visibility = Visibility.Hidden;


        }
        private void deleteCustomer_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {


            
        }

        private void closeBorder_addCustomer(object sender, RoutedEventArgs e)
        {
            addCustomerBorder.Visibility = Visibility.Hidden;
        }

        private void updateCustomer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateCustomerBorder.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateCustomerBorder.Visibility = Visibility.Hidden;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            

            updateCustomerBorder.Visibility = Visibility.Hidden;

        }

        private void searchText_DragEnter(object sender, DragEventArgs e)
        {
            
        }


        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;
            
        }

        private void filter_DragEnter(object sender, DragEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;
            
        }
    }
}
