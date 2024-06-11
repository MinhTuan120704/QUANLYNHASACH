using BLL.Services;
using DAL.Model;
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
    /// Interaction logic for StaticPage.xaml
    /// </summary>
    public partial class StaticPage : Page
    {
        public StaticPage()
        {
            InitializeComponent();
            LoadOrders();
        }
        public ObservableCollection<Order> Orders { get; set; }
        private static OrderService orderService;

        private void LoadOrders()
        {
            orderService = new OrderService();
            Orders = new ObservableCollection<Order>(orderService.GetAllOrder());
            OrdersListView.ItemsSource = Orders;
            count.Text = OrdersListView.Items.Count.ToString();
            var totalSum = OrdersListView.Items.OfType<Order>().Sum(item => item.TotalValue);
            sum.Text = totalSum.ToString();

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

        private void searchBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.Parse(startDate.Text) > DateTime.Parse(endDate.Text).Date.AddHours(23).AddMinutes(59).AddSeconds(59))
            {
                MessageBox.Show("Ngày bắt đầu phải bé hơn ngày kết thúc. Vui lòng nhập lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                orderService = new OrderService();
            
                var orders = new ObservableCollection<Order>(Orders.Where(order => order.Date <= DateTime.Parse(endDate.Text).Date.AddHours(23).AddMinutes(59).AddSeconds(59) && order.Date >= DateTime.Parse(startDate.Text)));
                OrdersListView.ItemsSource = orders;
                count.Text = OrdersListView.Items.Count.ToString();
                var totalSum = OrdersListView.Items.OfType<Order>().Sum(item => item.TotalValue);
                sum.Text = totalSum.ToString();
            }
            
        }
    }
}
