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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow newWindow = new MainWindow();
            //newWindow.Show();
            //this.Close();
        }

        private void bookManagementButton_Click(object sender, RoutedEventArgs e)
        {
            BookManagementPage newPage = new BookManagementPage();


            this.NavigationService.Navigate(newPage);
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
    }
}
