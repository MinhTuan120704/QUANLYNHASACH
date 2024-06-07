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
    /// Interaction logic for BookManagementPage.xaml
    /// </summary>
    public class AutoWidthGridViewColumn : GridViewColumn
    {
        public AutoWidthGridViewColumn()
        {
            WidthProperty.OverrideMetadata(typeof(AutoWidthGridViewColumn), new FrameworkPropertyMetadata(null, new CoerceValueCallback(OnCoerceWidth)));
        }

        private static object OnCoerceWidth(DependencyObject o, object baseValue)
        {
            return double.NaN;
        }
    }

    public partial class BookManagementPage : Page
    {
        //public List<Book> Books { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<string> BookTypes { get; set; }
        public ObservableCollection<string> Publishers { get; set; }
        public ObservableCollection<string> Authors { get; set; }
     
        private void LoadBookTypes()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            var bookTypes = Books.Select(book => book.BookType).Distinct().ToList();
            BookTypes = new ObservableCollection<string>(bookTypes);
        }
        private void LoadAuthors()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            var authors = Books.Select(book => book.Author).Distinct().ToList();
            Authors = new ObservableCollection<string>(authors);
        }
        private void LoadPublishers()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            var publishers = Books.Select(book => book.Publisher).Distinct().ToList();
            Publishers = new ObservableCollection<string>(publishers);
        }
        private void LoadBooks()
        {
            BookService bookService = new BookService();
            Books = new ObservableCollection<Book>(bookService.GetAllBook());
            BooksListView.ItemsSource = Books;
        }


        public BookManagementPage()
        {
            InitializeComponent();
            BookService bookService = new BookService();
            Books = new ObservableCollection<Book>(bookService.GetAllBook());
            BooksListView.ItemsSource = Books;
          
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
            BookTypeComboBox.SelectedIndex = -1;
            AuthorComboBox.SelectedIndex = -1;
            PublisherComboBox.SelectedIndex = -1;
            LoadBookTypes();
            LoadAuthors();
            LoadPublishers();
            BookTypeComboBox.ItemsSource = BookTypes;
            AuthorComboBox.ItemsSource = Authors;
            PublisherComboBox.ItemsSource = Publishers;

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

        private void addBook_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bookName.Text = "";
            bookType.Text = "";
            author.Text = "";
            publisher.Text = "";
            quantity.Text = "";
            unitPrice.Text = "";
            addBookBorder.Visibility = Visibility.Visible;
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
            if((bookName.Text == "") || (bookType.Text == "") || (author.Text == "") || (publisher.Text == "") || (quantity.Text == "") || (unitPrice.Text == "") )
            {
                MessageBox.Show("Không được để trống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                string BookName = bookName.Text;
                string BookType = bookType.Text;
                string Author = author.Text;
                string Publisher = publisher.Text;
                int Quantity;
                int UnitPrice;
                bool check_quantity = int.TryParse(quantity.Text, out Quantity);
                bool check_unitprice = int.TryParse(unitPrice.Text, out UnitPrice);
                if (check_quantity == false)
                {
                    quantity.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (check_unitprice == false)
                {
                    unitPrice.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (check_quantity && check_unitprice)
                {
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
                    Books = new ObservableCollection<Book>(bookService.GetAllBook());
                    bool isDuplicate = Books.Any(book => book.BookName == newBook.BookName && book.BookType == newBook.BookType && book.Author == newBook.Author && book.Publisher == newBook.Publisher);
                    if (!isDuplicate)
                    {
                        bookService.AddBook(newBook);
                    }
                    else
                    {
                        MessageBox.Show("Sách đã tồn tại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                    LoadBooks();
                    addBookBorder.Visibility = Visibility.Hidden;

                }


            }

        }
        private void deleteBook_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {


            if (BooksListView.SelectedItem is Book selectedBook)
            {
                BookService bookService = new BookService();
                var result = bookService.DeleteBook(selectedBook);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void closeBorder_addBook(object sender, RoutedEventArgs e)
        {
            addBookBorder.Visibility = Visibility.Hidden;
        }

        private void updateBook_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (BooksListView.SelectedItem is Book selectedBook)
            {
                bookName_update.Text = selectedBook.BookName;
                bookType_update.Text = selectedBook.BookType;
                author_update.Text = selectedBook.Author;
                publisher_update.Text = selectedBook.Publisher;
                quantity_update.Text = selectedBook.Quantity.ToString();
                unitPrice_update.Text = selectedBook.UnitPrice.ToString();
                updateBookBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateBookBorder.Visibility = Visibility.Hidden;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Book updateBook = new Book();
            BookService bookService = new BookService();
            Books = new ObservableCollection<Book>(bookService.GetAllBook());
            updateBook.BookID = Books.Where(book => book.BookName == bookName_update.Text && book.Author == author_update.Text).Select(book => book.BookID).FirstOrDefault();
            updateBook.BookName = bookName_update.Text;
            updateBook.BookType = bookType_update.Text;
            updateBook.Author = author_update.Text;
            updateBook.Publisher = publisher_update.Text;
            updateBook.Quantity = int.Parse(quantity_update.Text);
            updateBook.UnitPrice = int.Parse(unitPrice_update.Text);

            bookService.UpdateBook(updateBook);
            LoadBooks();

            updateBookBorder.Visibility= Visibility.Hidden;

        }

        private void searchText_DragEnter(object sender, DragEventArgs e)
        {
            var filteredBooks = Books.Where(book => book.BookName == searchText.Text).ToList();
            BooksListView.ItemsSource = filteredBooks;
        }


        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (searchText.Text == "")
            {
                BooksListView.ItemsSource = Books;
            }
            else
            {
                var filteredBooks = Books.Where(book => book.BookName == searchText.Text).ToList();
                BooksListView.ItemsSource = filteredBooks;

            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;
            string? selectedBookType = BookTypeComboBox.SelectedItem as string;
            string? selectedAuthor = AuthorComboBox.SelectedItem as string;
            string? selectedPublisher = PublisherComboBox.SelectedItem as string;
            if (selectedBookType != null && selectedAuthor != null && selectedPublisher != null)
            {
                var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Author == selectedAuthor && book.Publisher == selectedPublisher).ToList();
                BooksListView.ItemsSource = filteredBooks;

            }
            else
            {

                if (selectedBookType == null && selectedAuthor != null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.Author == selectedAuthor && book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor == null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor != null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Author == selectedAuthor).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor == null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor != null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.Author == selectedAuthor).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor == null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor == null && selectedPublisher == null)
                {
                    BooksListView.ItemsSource = Books;
                }
            }
        }

        private void filter_DragEnter(object sender, DragEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;
            string? selectedBookType = BookTypeComboBox.SelectedItem as string;
            string? selectedAuthor = AuthorComboBox.SelectedItem as string;
            string? selectedPublisher = PublisherComboBox.SelectedItem as string;
            if (selectedBookType != null && selectedAuthor != null && selectedPublisher != null)
            {
                var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Author == selectedAuthor && book.Publisher == selectedPublisher).ToList();
                BooksListView.ItemsSource = filteredBooks;

            }
            else
            {

                if (selectedBookType == null && selectedAuthor != null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.Author == selectedAuthor && book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor == null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor != null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType && book.Author == selectedAuthor).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType != null && selectedAuthor == null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.BookType == selectedBookType).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor != null && selectedPublisher == null)
                {
                    var filteredBooks = Books.Where(book => book.Author == selectedAuthor).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor == null && selectedPublisher != null)
                {
                    var filteredBooks = Books.Where(book => book.Publisher == selectedPublisher).ToList();
                    BooksListView.ItemsSource = filteredBooks;
                }

                if (selectedBookType == null && selectedAuthor == null && selectedPublisher == null)
                {
                    BooksListView.ItemsSource = Books;
                }
            }
        }
    }
}
