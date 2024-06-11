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
        public int actualquantity { get; set; }
        private static BookService bookService;
        private static ConstraintsService constraintsService;
        private static bool isAdminBorderVisible;
        private static int PreviousSelectedFilter_BookType = -1;
        private static int PreviousSelectedFilter_Author = -1;
        private static int PreviousSelectedFilter_Publisher = -1;

        private void LoadBookTypes()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            bookService = new BookService();
            BookTypes = new ObservableCollection<string>(bookService.GetBookTypes());
        }
        private void LoadAuthors()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            bookService = new BookService();
            Authors = new ObservableCollection<string>(bookService.GetAuthors());
        }
        private void LoadPublishers()
        {
            // Lấy tất cả các loại BookType từ danh sách Books và loại bỏ các phần tử trùng lặp
            bookService = new BookService();
            Publishers = new ObservableCollection<string>(bookService.GetPublishers());
        }
        private void LoadBooks()
        {
            bookService = new BookService();
            Books = new ObservableCollection<Book>(bookService.GetAllBook());
            BooksListView.ItemsSource = Books;
        }

        public BookManagementPage()
        {
            InitializeComponent();
            bookService = new BookService();
            isAdminBorderVisible = false;
            LoadBooks();
        }

        
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
            bookService = new BookService();
            LoadBookTypes();
            LoadAuthors();
            LoadPublishers();

            BookTypeComboBox.ItemsSource = BookTypes;
            AuthorComboBox.ItemsSource = Authors;
            PublisherComboBox.ItemsSource = Publishers;
            BookTypeComboBox.SelectedIndex = PreviousSelectedFilter_BookType;
            AuthorComboBox.SelectedIndex = PreviousSelectedFilter_Author;
            PublisherComboBox.SelectedIndex = PreviousSelectedFilter_Publisher;

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
            bookService = new BookService();
            constraintsService = new ConstraintsService();
            int qd1 = int.Parse(constraintsService.GetConstraintValue("QĐ1"));
            if ((bookName.Text == "") || (bookType.Text == "") || (author.Text == "") || (publisher.Text == "") || (quantity.Text == "") || (unitPrice.Text == "") )
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int Quantity;
                int UnitPrice;
                if (int.TryParse(quantity.Text, out Quantity) == false && int.TryParse(unitPrice.Text, out UnitPrice) == false)
                {
                    quantity.Text = "";
                    unitPrice.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (int.TryParse(unitPrice.Text, out UnitPrice) == false)
                {
                    unitPrice.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (int.TryParse(quantity.Text, out Quantity) == false)
                {
                    quantity.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (int.TryParse(quantity.Text, out Quantity) && int.TryParse(unitPrice.Text, out UnitPrice))
                {
                    if (Quantity < qd1)
                    {
                        MessageBox.Show("Số lượng nhập tối thiểu là " + qd1.ToString(), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        quantity.Text = "";
                    }
                    else
                    {
                        if (bookService.AddBook(bookName.Text, bookType.Text, author.Text, publisher.Text, Quantity, UnitPrice))
                        {
                            MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadBooks();
                            addBookBorder.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            MessageBox.Show("Sách đã tồn tại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }
                    
                }
            }
        }
        private void deleteBook_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            bookService = new BookService();
            if (BooksListView.SelectedItem is Book selectedBook)
            {
                bookService.DeleteBook(selectedBook);
                
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadBooks();
                
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void closeBorder_addBook(object sender, RoutedEventArgs e)
        {
            addBookBorder.Visibility = Visibility.Hidden;
        }

        private void updateBook_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bookService = new BookService();
            constraintsService = new ConstraintsService();
            int qd1 = int.Parse(constraintsService.GetConstraintValue("QĐ1"));
            int qd2 = int.Parse(constraintsService.GetConstraintValue("QĐ2"));
            if (BooksListView.SelectedItem is Book selectedBook)
            {
                if(qd2 < selectedBook.Quantity)
                {
                    MessageBox.Show("Số lượng sách tồn trong kho nhiều nhất là " + qd2.ToString(), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    actualquantity = selectedBook.Quantity;
                    bookName_update.Text = selectedBook.BookName;
                    bookType_update.Text = selectedBook.BookType;
                    author_update.Text = selectedBook.Author;
                    publisher_update.Text = selectedBook.Publisher;
                    quantity_update.Text = "";
                    unitPrice_update.Text = selectedBook.UnitPrice.ToString();
                    updateBookBorder.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateBookBorder.Visibility = Visibility.Hidden;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            bookService = new BookService();
            constraintsService = new ConstraintsService();
            int qd1 = int.Parse(constraintsService.GetConstraintValue("QĐ1"));
            int qd2 = int.Parse(constraintsService.GetConstraintValue("QĐ2"));
            if ((bookName_update.Text == "") || (bookType_update.Text == "") || (author_update.Text == "") || (publisher_update.Text == "") || (quantity_update.Text == "") || (unitPrice_update.Text == ""))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int Quantity;
                int UnitPrice;
                if (int.TryParse(quantity_update.Text, out Quantity) == false && int.TryParse(unitPrice_update.Text, out UnitPrice) == false)
                {
                    quantity_update.Text = "";
                    unitPrice_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (int.TryParse(unitPrice_update.Text, out UnitPrice) == false)
                {
                    unitPrice_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if(int.TryParse(quantity_update.Text, out Quantity) == false)
                {
                    quantity_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (int.TryParse(quantity_update.Text, out Quantity) && int.TryParse(unitPrice_update.Text, out UnitPrice))
                {
                    if (Quantity < qd1)
                    {
                        MessageBox.Show("Số lượng nhập tối thiểu là " + qd1.ToString(), "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        quantity.Text = "";
                    }
                    else
                    {

                        if (bookService.UpdateBook(bookName_update.Text, bookType_update.Text, author_update.Text, publisher_update.Text, Quantity + actualquantity, UnitPrice))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadBooks();
                            updateBookBorder.Visibility = Visibility.Hidden;
                        } 
                    }
                }
            }
        }

        private void searchText_DragEnter(object sender, DragEventArgs e)
        {
            BooksListView.ItemsSource = bookService.SearchBook(searchText.Text);
        }


        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (searchText.Text == "")
            {
                bookService = new BookService();
                LoadBooks();
            }
            else
            {
                BooksListView.ItemsSource = bookService.SearchBook(searchText.Text);
            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;

            PreviousSelectedFilter_BookType = BookTypeComboBox.SelectedIndex;
            PreviousSelectedFilter_Author = AuthorComboBox.SelectedIndex;
            PreviousSelectedFilter_Publisher = PublisherComboBox.SelectedIndex;

            string? selectedBookType = BookTypeComboBox.SelectedItem as string;
            string? selectedAuthor = AuthorComboBox.SelectedItem as string;
            string? selectedPublisher = PublisherComboBox.SelectedItem as string;

            BooksListView.ItemsSource = bookService.FilterBook(selectedBookType,selectedAuthor,selectedPublisher);
            
        }

        private void filter_DragEnter(object sender, DragEventArgs e)
        {
            filterBorder.Visibility = Visibility.Collapsed;

            PreviousSelectedFilter_BookType = BookTypeComboBox.SelectedIndex;
            PreviousSelectedFilter_Author = AuthorComboBox.SelectedIndex;
            PreviousSelectedFilter_Publisher = PublisherComboBox.SelectedIndex;

            string? selectedBookType = BookTypeComboBox.SelectedItem as string; 
            string? selectedAuthor = AuthorComboBox.SelectedItem as string;
            string? selectedPublisher = PublisherComboBox.SelectedItem as string;

            BooksListView.ItemsSource = bookService.FilterBook(selectedBookType, selectedAuthor, selectedPublisher);
            
        }

        private void BookTypeReload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviousSelectedFilter_BookType = -1;
            BookTypeComboBox.SelectedIndex = PreviousSelectedFilter_BookType;
        }

        private void AuthorReload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviousSelectedFilter_Author = -1;
            AuthorComboBox.SelectedIndex = PreviousSelectedFilter_Author;
        }

        private void PublisherReload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviousSelectedFilter_Publisher = -1;
            PublisherComboBox.SelectedIndex = PreviousSelectedFilter_Publisher;
        }
    }
}
