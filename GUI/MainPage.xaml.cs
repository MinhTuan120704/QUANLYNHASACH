using BLL.IServices;
using BLL.Services;
using DAL.Context;
using DAL.Model;using System;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>

    public partial class MainPage : Page
    {
        private static AccountService accountService;
        string position;

        public MainPage()
        {
            InitializeComponent();
            accountService = new AccountService();
            position = accountService.GetAccountPosition(GlobalVariables.UserText);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow newWindow = new MainWindow();
            //newWindow.Show();
            //this.Close();
        }

        private void bookManagementButton_Click(object sender, RoutedEventArgs e)
        {
            if (position == "NhanVien")
            {
                MessageBox.Show("Không có quyền truy cập", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                BookManagementPage newPage = new BookManagementPage();


                this.NavigationService.Navigate(newPage);
            }
        }

        private void bookManagementButton_MouseEnter(object sender, MouseEventArgs e)
        {
            bookManagementButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            bookManagementButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bookManagementButton.Cursor = Cursors.Hand;
        }

        private void bookManagementButton_MouseLeave(object sender, MouseEventArgs e)
        {
            bookManagementButton.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bookManagementButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            bookManagementButton.Cursor = Cursors.Arrow;
        }

        private void customerManagementButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerPage newPage = new CustomerPage();


            this.NavigationService.Navigate(newPage);
        }

        private void customerManagementButton_MouseEnter(object sender, MouseEventArgs e)
        {
            customerManagementButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            customerManagementButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            customerManagementButton.Cursor = Cursors.Hand;
        }

        private void customerManagementButton_MouseLeave(object sender, MouseEventArgs e)
        {
            customerManagementButton.Background = new SolidColorBrush(Color.FromRgb(252, 255, 255));
            customerManagementButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            customerManagementButton.Cursor = Cursors.Arrow;
        }

        private void invoiceButton_Click(object sender, RoutedEventArgs e)
        {
            BillPage newPage = new BillPage();
            this.NavigationService.Navigate(newPage);
        }

        private void invoiceButton_MouseEnter(object sender, MouseEventArgs e)
        {
            invoiceButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            invoiceButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            invoiceButton.Cursor = Cursors.Hand;
        }

        private void invoiceButton_MouseLeave(object sender, MouseEventArgs e)
        {
            invoiceButton.Background = new SolidColorBrush(Color.FromRgb(252, 255, 255));
            invoiceButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            invoiceButton.Cursor = Cursors.Arrow;
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            if (position == "NhanVien")
            {
                MessageBox.Show("Không có quyền truy cập", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            } 
            else { 
                SettingPage newPage = new SettingPage();
                this.NavigationService.Navigate(newPage);
            }
        }

        private void settingButton_MouseEnter(object sender, MouseEventArgs e)
        {
            settingButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            settingButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            settingButton.Cursor = Cursors.Hand;
        }

        private void settingButton_MouseLeave(object sender, MouseEventArgs e)
        {
            settingButton.Background = new SolidColorBrush(Color.FromRgb(252, 255, 255));
            settingButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            settingButton.Cursor = Cursors.Arrow;
        }

        private void statisticButton_Click(object sender, RoutedEventArgs e)
        {

            if (position == "NhanVien")
            {
                MessageBox.Show("Không có quyền truy cập", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                StaticPage newPage = new StaticPage();
                this.NavigationService.Navigate(newPage);

            }
        }

        private void statisticButton_MouseEnter(object sender, MouseEventArgs e)
        {
            statisticButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            statisticButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            statisticButton.Cursor = Cursors.Hand;
        }

        private void statisticButton_MouseLeave(object sender, MouseEventArgs e)
        {
            statisticButton.Background = new SolidColorBrush(Color.FromRgb(252, 255, 255));
            statisticButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            statisticButton.Cursor = Cursors.Arrow;
        }

        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage newPage = new LoginPage();
            this.NavigationService.Navigate(newPage);
        }

        private void signOutButton_MouseEnter(object sender, MouseEventArgs e)
        {
            signOutButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            signOutButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            signOutButton.Cursor = Cursors.Hand;
        }

        private void signOutButton_MouseLeave(object sender, MouseEventArgs e)
        {
            signOutButton.Background = new SolidColorBrush(Color.FromRgb(252, 255, 255));
            signOutButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            signOutButton.Cursor = Cursors.Arrow;
        }
    }
}
