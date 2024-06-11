using BLL.IServices;
using BLL.Services;
using DAL.Context;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>

    public partial class SettingPage : Page
    {
        private static ConstraintsService constraintsService;
        private static AccountService accountService;
        public ObservableCollection<Account> Accounts { get; set; }

        public SettingPage()
        {
            InitializeComponent();
            Load();
            LoadAccounts();

        }

        private void event_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void event_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }
        private void LoadAccounts()
        {
            accountService = new AccountService();
            Accounts = new ObservableCollection<Account>(accountService.GetAllAccount());
            AccountsListView.ItemsSource = Accounts;
        }

        private void Load()
        {
            constraintsService = new ConstraintsService();
            qd1.Text = constraintsService.GetConstraintValue("QĐ1").ToString();
            qd2.Text = constraintsService.GetConstraintValue("QĐ2").ToString();
            qd3.Text = constraintsService.GetConstraintValue("QĐ3").ToString();
            qd4.Text = constraintsService.GetConstraintValue("QĐ4").ToString();
            qd5.Text = constraintsService.GetConstraintValue("QĐ5").ToString();
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
            adminButton.Cursor = Cursors.Hand;
        }

        private void adminButton_MouseLeave(object sender, MouseEventArgs e)
        {
            adminButton.Cursor = Cursors.Arrow;
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            
            constraintsService = new ConstraintsService();
            constraintsService.UpdateConstraint("QĐ1", qd1.Text);
            constraintsService.UpdateConstraint("QĐ2", qd2.Text);
            constraintsService.UpdateConstraint("QĐ3", qd3.Text);
            constraintsService.UpdateConstraint("QĐ4", qd4.Text);
            constraintsService.UpdateConstraint("QĐ5", qd5.Text);
            Load();

        }

        private void system_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderSystem.Visibility = Visibility.Visible;
            borderAccount.Visibility = Visibility.Hidden;
        }

        private void account_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderAccount.Visibility = Visibility.Visible;
            borderSystem.Visibility = Visibility.Hidden;
        }

        private void updateAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            accountService = new AccountService();
            if (AccountsListView.SelectedItem is Account selectedAccount)
            {
                updateAccountBorder.Visibility = Visibility.Visible;
                accountName_update.Text = selectedAccount.AccountName;
                password_update.Text = selectedAccount.Password;
                position_update.Text = selectedAccount.Position;
                created_update.Text = selectedAccount.Created.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void addAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            addAccountBorder.Visibility = Visibility.Visible;
        }

        private void closeBorder_addAccount(object sender, RoutedEventArgs e)
        {
            addAccountBorder.Visibility = Visibility.Hidden;

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            accountService = new AccountService();
            if ((accountName.Text == "") || (password.Text == "") || (position.Text == "") || (created.Text == ""))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DateTime Created;
                if (DateTime.TryParse(created.Text, out Created) == false)
                {
                    created.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (DateTime.TryParse(created.Text, out Created))
                {
                    if (accountService.AddAccount(accountName.Text, password.Text, position.Text, Created))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadAccounts();
                        addAccountBorder.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateAccountBorder.Visibility = Visibility.Hidden;

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            accountService = new AccountService();
            if ((accountName_update.Text == "") || (password_update.Text == "") || (position_update.Text == "") || (created_update.Text == ""))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DateTime Created;
                if (DateTime.TryParse(created_update.Text, out Created) == false)
                {
                    created_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (DateTime.TryParse(created_update.Text, out Created))
                {
                    if (accountService.UpdateAccount(accountName_update.Text, password_update.Text, position_update.Text, Created))
                    {
                        MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadAccounts();
                        updateAccountBorder.Visibility= Visibility.Hidden;
                    }
                    

                }
            }
        }

        private void deleteAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            accountService = new AccountService();
            if (AccountsListView.SelectedItem is Account selectedAccount)
            {
                accountService = new AccountService();
                accountService.DeleteAccount(selectedAccount);

                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadAccounts();


            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
