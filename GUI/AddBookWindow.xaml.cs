using BLL.Services;
using DAL.Model;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {

        public AddBookWindow()
        {
            InitializeComponent();
            WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

            string BookName = bookName.Text;
            bookName.Text = "";
            string BookType = bookType.Text;
            bookType.Text = "";
            string Author = author.Text;
            author.Text = "";
            string Publisher = publisher.Text;
            publisher.Text = "";
            int Quantity = int.Parse(quantity.Text);
            quantity.Text = "";
            int UnitPrice = int.Parse(unitPrice.Text);
            unitPrice.Text = "";

            // Tạo đối tượng Book mới
            Book newBook = new Book()
            {
                BookName = BookName,
                BookType = BookType,
                Author = Author,
                Publisher = Publisher,
                Quantity = Quantity,
                UnitPrice = UnitPrice
            };

            BookService bookService = new BookService();
            bookService.AddBook(newBook);

            // Đóng cửa sổ này sau khi thêm sách
            this.Close();
        }

        private void closeBorder_addBook(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
