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
using BLL;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Login login = new Login();
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void user_GotFocus(object sender, RoutedEventArgs e)
        {
            if (user.Text == "Username")
            {
                user.Text = string.Empty;
                user.Opacity = 1;

            }
        }


        private void passWord_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passWord.Text == "Password")
            {
                passWord.Text = string.Empty;
                passWord.Opacity = 1;

            }

        }

        private void loginButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            loginButton.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            loginButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            loginButton.Cursor = Cursors.Hand;

        }

        private void loginButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            loginButton.Background = new SolidColorBrush(Color.FromRgb(252, 222, 222));
            loginButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            loginButton.Cursor = Cursors.Arrow;
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của màn hình mới
            //MyMainWindow newWindow = new MyMainWindow();
            //newWindow.Show();

            //this.Close();
            if (login.CheckLoginBLL(user.Text.ToString(), passWord.Text.ToString()) == 0)
            {
                MessageBox.Show("không tồn tại");
            }
            else
            {
                GlobalVariables.UserText = user.Text.ToString();
                MainPage newPage = new MainPage();
                // Điều hướng đến trang mới
                this.NavigationService.Navigate(newPage);
            }
        }

        private void passWord_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
