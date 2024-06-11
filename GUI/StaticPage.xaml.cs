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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using Microsoft.Extensions.Primitives;




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

        private void reportPDF_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            orderService = new OrderService();

            var orders = new ObservableCollection<Order>(Orders.Where(order => order.Date <= DateTime.Parse(endDate.Text).Date.AddHours(23).AddMinutes(59).AddSeconds(59) && order.Date >= DateTime.Parse(startDate.Text)));
            OrdersListView.ItemsSource = orders;
            count.Text = OrdersListView.Items.Count.ToString();
            var debtSum = OrdersListView.Items.OfType<Order>().Sum(item => item.RemainingValue);
            PdfDocument document = new PdfDocument();

            // Thêm một trang mới vào tài liệu
            PdfPage page = document.AddPage();

            // Lấy đối tượng vẽ cho trang
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Vẽ một văn bản đơn giản lên trang
            XFont font = new XFont("Times New Roman", 36);
            gfx.DrawString("Báo cáo doanh thu", font, XBrushes.Black,
                new XRect(0, 50, page.Width, page.Height),
                XStringFormats.TopCenter);

            XFont font1 = new XFont("Times New Roman", 14, XFontStyleEx.Italic);
            gfx.DrawString("(Từ ngày "+DateTime.Parse(startDate.Text).ToString(("dd/MM/yyyy"))+" Đến ngày "+ DateTime.Parse(endDate.Text).ToString(("dd/MM/yyyy")) + ")", font1, XBrushes.Black,
                new XRect(0, 100, page.Width, page.Height),
                XStringFormats.TopCenter);

            XFont font2 = new XFont("Times New Roman", 14);
            gfx.DrawString("Tổng số hóa đơn: " + count.Text, font2, XBrushes.Black,
                new XRect(50, 150, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Tổng doanh thu: " + sum.Text, font2, XBrushes.Black,
                new XRect(50, 180, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Tổng số nợ: " + debtSum.ToString(), font2, XBrushes.Black,
                new XRect(50, 210, page.Width, page.Height),
                XStringFormats.TopLeft);
            XFont font3 = new XFont("Times New Roman", 11);

            double startX = 30;
            double startY = 250;
            double cellWidth = 90;
            double cellHeight = 30;
            int numRows = int.Parse(count.Text) + 1;
            int numCols = 6;
            for (int col = 0; col < numCols; col++)
            {
                double x = startX + col * cellWidth;
                double y = startY ;
                gfx.DrawRectangle(XPens.Black, x, y, cellWidth, cellHeight);
                string text;
                switch (col)
                {
                    case 0:
                        text = "Mã hóa đơn";
                        break;                    
                    case 1:
                        text = "Ngày hóa đơn";
                        break;                   
                    case 2:
                        text = "Mã khách hàng";
                        break;                   
                    case 3:
                        text = "Tổng cộng";
                        break;                    
                    case 4:
                        text = "Thanh toán";
                        break;
                    default:
                        text = "Còn nợ";
                        break;
                }
                gfx.DrawString(text, font3, XBrushes.Black, new XRect(x, y, cellWidth, cellHeight), XStringFormats.Center);
            }
            // Vẽ các ô của bảng
            for (int row = 1; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Order order = (Order)OrdersListView.Items[row-1];
                    string text;
                
                    double x = startX + col * cellWidth;
                    double y = startY + row * cellHeight;
                    switch (col)
                    {
                        case 0:
                            text = order.OrderID.ToString();
                            break;
                        case 1:
                            text = order.Date.ToString("dd/MM/yyyy");
                            break;
                        case 2:
                            text = order.ConsumerID.ToString();
                            break;
                        case 3:
                            text = order.TotalValue.ToString();
                            break;
                        case 4:
                            text = order.PaidValue.ToString();
                            break;
                        default:
                            text = order.RemainingValue.ToString();
                            break;
                    }
                    gfx.DrawRectangle(XPens.Black, x, y, cellWidth, cellHeight);

                    // Vẽ văn bản trong ô (dùng làm ví dụ)
                    gfx.DrawString(text, font3, XBrushes.Black, new XRect(x, y, cellWidth, cellHeight), XStringFormats.Center);
                }
            }
            // Lưu tài liệu PDF vào đĩa
            document.Save("Chung1.pdf");



            // Đóng tài liệu
            document.Close();
            Process.Start(new ProcessStartInfo("Chung1.pdf") { UseShellExecute = true });

        }
    }
}
