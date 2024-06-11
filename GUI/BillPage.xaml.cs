using BLL.IServices;
using BLL.Services;
using DAL.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        private static ConsumerService consumerService;

        private static BookOrderService bookOrderService;

        private static double OrderAmount = 0;
        
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

            foreach(Book book in Books)
            {
                book.BookID = bookService.GetBookID(book.BookName, book.Author);
            }
            dataGridBook.ItemsSource = Books;
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
            orderService = new OrderService();
            consumerService = new ConsumerService();
            bookOrderService = new BookOrderService();
            bookService = new BookService();
            if(OrdersListView.SelectedItem is Order order)
            {
                TextNameBookOrder.Text = consumerService.GetConsumerNameByID(order.ConsumerID);
                TextPhoneBookOrder.Text =consumerService.GetConsumerPhoneByID(order.ConsumerID);
                TextPaidBookOrder.Text = order.PaidValue.ToString() + " đ";
                OrderAmountTextBookOrder.Text = order.TotalValue.ToString() + " đ";

                List<BookOrder> id = bookOrderService.GetBookOrderbyOrderID(order.OrderID);

                foreach(BookOrder idItem in id)
                {
                    Book? book = bookService.GetBookByID(idItem.BookID);
                    BookOrderShow cTHD = new BookOrderShow(order.OrderID,idItem.BookID,book.BookName,idItem.Quantity,idItem.Quantity*book.UnitPrice*105/100);
                    dataGridDetailsBookOrder.Items.Add(cTHD);
                }
                
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            BookOrderBorder.Visibility = Visibility.Visible;

        }

        private void ThemHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OrderAmount = 0;
            TextPhone.Text = "";
            TextName.Text = "";
            TextPaid.Text = "";
            addOrderBorder.Visibility = Visibility.Visible;
        }

        private void closeBorder_addOrder(object sender, RoutedEventArgs e)
        {
            TextName.Text = "";
            TextPhone.Text = "";
            addOrderBorder.Visibility = Visibility.Hidden;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            bool update = false;
            bookService = new BookService();
            if(bookQuantity.Text == "" || !int.TryParse(bookQuantity.Text, out int quantity))
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                bookQuantity.Text = "";
            }
            else if(dataGridBook.SelectedItem is Book selectedBook)
            {
                Book? book = bookService.GetBookByID(selectedBook.BookID);

                for(int i = 0; i < dataGridDetails.Items.Count; i++)
                {
                    BookSell booksell = (BookSell)dataGridDetails.Items[i];
                    if (book.BookID == booksell.BookID && book != null && booksell != null)
                    {
                        if (int.Parse(bookQuantity.Text) != booksell.Quantity)
                        {
                            dataGridDetails.Items.Remove(booksell);
                            OrderAmount -= booksell.Amount;
                            booksell.Quantity = int.Parse(bookQuantity.Text);
                            booksell.Amount = (double)booksell.Quantity * booksell.UnitPrice;
                            dataGridDetails.Items.Add(booksell);
                            OrderAmount += booksell.Amount;
                            update = true;
                            OrderAmountText.Text = OrderAmount.ToString() + " đ";
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            addBookBorder.Visibility = Visibility.Hidden;
                        }
                        if(int.Parse(bookQuantity.Text) == booksell.Quantity && !update)
                        {
                            MessageBox.Show("Sách đã được thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }

                if(!update)
                {
                    BookSell bookSell = new BookSell(selectedBook.BookID, selectedBook.BookName, int.Parse(bookQuantity.Text), selectedBook.UnitPrice);
                    dataGridDetails.Items.Add(bookSell);
                    OrderAmount += bookSell.Amount;
                    OrderAmountText.Text = OrderAmount.ToString() + " đ";
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    addBookBorder.Visibility = Visibility.Hidden;
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ThemSach_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            bookService = new BookService();
            bookName.Text = "";
            bookQuantity.Text = "";
            dataGridBook.ItemsSource = bookService.GetAllBook();
            addBookBorder.Visibility = Visibility.Visible;
        }

        private void closeBorder_addBook(object sender, RoutedEventArgs e)
        {
            addBookBorder.Visibility = Visibility.Hidden;
        }

        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bookService = new BookService();
            if (bookName.Text == "")
            {               
                LoadBooks();
            }
            else
            {
                dataGridBook.ItemsSource = bookService.SearchBook(bookName.Text);
            }
        }

        private void LostFocus(object sender, RoutedEventArgs e)
        {
            addbookGrid.Focus();
        }

        private void addbookGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addbookGrid.Focus();
        }

        private void XoaSach_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dataGridDetails.SelectedItem is BookSell selectedBook)
            {
                BookSell bookSell = selectedBook;

                for (int i = 0; i < dataGridDetails.Items.Count; i++)
                {
                    BookSell booksell = (BookSell)dataGridDetails.Items[i];
                    if (bookSell.BookID == booksell.BookID && bookSell != null && booksell != null)
                    {
                        OrderAmount -= booksell.Amount;
                        dataGridDetails.Items.Remove(booksell);
                        OrderAmountText.Text = OrderAmount.ToString() + " đ";
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            orderService = new OrderService();
            consumerService = new ConsumerService();
            bookOrderService = new BookOrderService();
            if(TextName.Text == "" || TextPhone.Text == "" || TextPaid.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                check = false;
            }
            else
            {
                string Phone = TextPhone.Text;
                string Paid = TextPaid.Text;
                for(int i = 0; i < Phone.Length; i++) 
                {
                    if (Phone[i] < '0' && Phone[i] > '9')
                    {
                        MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        TextPhone.Text = "";
                        check = false;
                    }
                }

                for (int i = 0; i < Paid.Length; i++)
                {
                    if (Paid[i] < '0' && Paid[i] > '9')
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        TextPaid.Text = "";
                        check = false;
                    }
                }
            }

            if(check)
            {
                Order order = new Order();
                order.ConsumerID = consumerService.GetConsumerIDFromDB(TextPhone.Text);
                order.TotalValue = (int)OrderAmount;
                order.PaidValue = int.Parse(TextPaid.Text);
                order.RemainingValue = order.TotalValue - order.PaidValue;
                order.Date = DateTime.Now;
                orderService.AddOrder(order);

                for (int i = 0; i < dataGridDetails.Items.Count; i++) 
                {
                    BookSell? bookSell = (BookSell)dataGridDetails.Items[i];
                    BookOrder bookOrder = new BookOrder();  
                    bookOrder.OrderID = orderService.GetOrderID(order.ConsumerID,order.Date);
                    bookOrder.BookID = bookSell.BookID;
                    bookOrder.Quantity = bookSell.Quantity;
                    bookOrderService.AddBookOrder(bookOrder);
                }

                
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                addOrderBorder.Visibility = Visibility.Hidden;
                LoadOrders();
            }
        }

        private void SuaHoaDon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            orderService = new OrderService();

            if(OrdersListView.SelectedItem is Order order)
            {
                OrderID_update.Text = order.OrderID.ToString();
                Date_update.Text = order.Date.ToString();
                ConsumerID_update.Text = order.ConsumerID.ToString();
                Total_update.Text = order.TotalValue.ToString();
                Paid_update.Text = order.PaidValue.ToString();
                Debt_update.Text = order.RemainingValue.ToString();
                updateOrderBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void close_UpdateBorder(object sender, MouseButtonEventArgs e)
        {
            updateOrderBorder.Visibility = Visibility.Hidden;
            OrderID_update.Text = "";
            Date_update.Text = "";
            Total_update.Text = "";
            ConsumerID_update.Text = "";
            Paid_update.Text = "";
            Debt_update.Text = "";
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            orderService = new OrderService();
            if(Paid_update.Text == "")
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int paidvalue;
                int totalvalue = int.Parse(Total_update.Text);
                if(!int.TryParse(Paid_update.Text, out paidvalue))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Paid_update.Text = "";
                }
                else if (paidvalue > totalvalue)
                {
                    MessageBox.Show("Số tiền thanh toán không được vượt quá tổng tiền của hóa đơn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Paid_update.Text = "";
                }
                else
                {
                    if(orderService.UpdateOrder(int.Parse(OrderID_update.Text),DateTime.Parse(Date_update.Text),int.Parse(ConsumerID_update.Text), int.Parse(Total_update.Text), paidvalue, totalvalue - paidvalue))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadOrders();
                        updateOrderBorder.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void close_UpdateBorder(object sender, RoutedEventArgs e)
        {
            updateOrderBorder.Visibility = Visibility.Hidden;
            OrderID_update.Text = "";
            Date_update.Text = "";
            Total_update.Text = "";
            ConsumerID_update.Text = "";
            Paid_update.Text = "";
            Debt_update.Text = "";
        }

        private void close_BookOrderBorder(object sender, RoutedEventArgs e)
        {
            BookOrderBorder.Visibility = Visibility.Hidden;
            TextNameBookOrder.Text = "";
            TextPhoneBookOrder.Text = "";
            TextPaidBookOrder.Text = "";
            OrderAmountTextBookOrder.Text = "";
            dataGridDetailsBookOrder.Items.Clear();
            
        }

        private void XoaHoaDon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            orderService = new OrderService();

            if (OrdersListView.SelectedItem is Order order)
            {
                orderService.DeleteOrder(order);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void XHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BookOrderShow firstOrder = (BookOrderShow)dataGridDetailsBookOrder.Items[0];

            string debt = (int.Parse(OrderAmountTextBookOrder.Text.Replace(" đ", "")) - int.Parse(TextPaidBookOrder.Text.Replace(" đ", ""))).ToString();
            PdfDocument document = new PdfDocument();

            // Thêm một trang mới vào tài liệu
            PdfPage page = document.AddPage();

            // Lấy đối tượng vẽ cho trang
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Vẽ một văn bản đơn giản lên trang
            XFont font = new XFont("Times New Roman", 36);
            gfx.DrawString("Chi tiết hóa đơn", font, XBrushes.Black,
                new XRect(0, 50, page.Width, page.Height),
                XStringFormats.TopCenter);

            XFont font1 = new XFont("Times New Roman", 14, XFontStyleEx.Italic);
            gfx.DrawString("(Ngày xuất: " + DateTime.Now.ToString(("dd/MM/yyyy"))+ ")", font1, XBrushes.Black,
                new XRect(0, 100, page.Width, page.Height),
                XStringFormats.TopCenter);

            XFont font2 = new XFont("Times New Roman", 14);
            gfx.DrawString("Mã hóa đơn: " + firstOrder.OrderID.ToString(), font2, XBrushes.Black,
                new XRect(50, 150, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Tên khách hàng: " + TextNameBookOrder.Text, font2, XBrushes.Black,
                new XRect(50, 180, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("SĐT: " + TextPhoneBookOrder.Text, font2, XBrushes.Black,
                new XRect(50, 210, page.Width, page.Height),
                XStringFormats.TopLeft);

            XFont font3 = new XFont("Times New Roman", 11);


            double startX = 20;
            double startY = 250;
            double cellWidth = 140;
            double cellHeight = 30;
            int numRows = dataGridDetailsBookOrder.Items.Count + 1;
            int numCols = 4;
            for (int col = 0; col < numCols; col++)
            {
                double x = startX + col * cellWidth;
                double y = startY;
                gfx.DrawRectangle(XPens.Black, x, y, cellWidth, cellHeight);
                string text;
                switch (col)
                {
                    case 0:
                        text = "Mã sách";
                        break;
                    case 1:
                        text = "Tên sách";
                        break;
                    case 2:
                        text = "Số lượng";
                        break;
                    default:
                        text = "Thành tiền";
                        break;
                }
                gfx.DrawString(text, font3, XBrushes.Black, new XRect(x, y, cellWidth, cellHeight), XStringFormats.Center);
            }
            // Vẽ các ô của bảng
            for (int row = 1; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    BookOrderShow order = (BookOrderShow)dataGridDetailsBookOrder.Items[row - 1];
                    string text;

                    double x = startX + col * cellWidth;
                    double y = startY + row * cellHeight;
                    switch (col)
                    {
                        case 0:
                            text = order.BookID.ToString();
                            break;
                        case 1:
                            text = order.BookName.ToString();
                            break;
                        case 2:
                            text = order.Quantity.ToString();
                            break;
                        default:
                            text = order.Total.ToString();
                            break;
                    }
                    gfx.DrawRectangle(XPens.Black, x, y, cellWidth, cellHeight);

                    // Vẽ văn bản trong ô (dùng làm ví dụ)
                    gfx.DrawString(text, font3, XBrushes.Black, new XRect(x, y, cellWidth, cellHeight), XStringFormats.Center);
                }
            }
            gfx.DrawString("Thành tiền: " + OrderAmountTextBookOrder.Text, font2, XBrushes.Black,
                new XRect(50, startY + 5 * cellHeight, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Thanh toán: " + TextPaidBookOrder.Text, font2, XBrushes.Black,
                new XRect(50, startY + 5 * cellHeight+30, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString("Số nợ: " + debt +" đ", font2, XBrushes.Black,
                new XRect(50, startY + 5 * cellHeight + 60, page.Width, page.Height),
                XStringFormats.TopLeft);
            //Lưu tài liệu PDF vào đĩa
            document.Save("Chung1.pdf");



            // Đóng tài liệu
            document.Close();
            Process.Start(new ProcessStartInfo("Chung1.pdf") { UseShellExecute = true });
        }
    }
}
