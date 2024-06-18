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
using static System.Reflection.Metadata.BlobBuilder;

namespace GUI
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    

    public partial class CustomerPage : Page
    {
        private static ConstraintsService ConstraintsService;

        private static int G_Debt;
        public CustomerPage()
        {
            InitializeComponent();
            LoadConsumers();

        }
        private static ConsumerService consumerService;
        public ObservableCollection<Consumer> Consumers { get; set; }

        private bool isAdminBorderVisible = false;

        private void LoadConsumers()
        {
            consumerService = new ConsumerService();
            Consumers = new ObservableCollection<Consumer>(consumerService.GetAllConsumer());
            CustomersListView.ItemsSource = Consumers;
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

        private void addCustomer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            customerName.Text = ""; 
            address.Text = ""; 
            phone.Text = ""; 
            email.Text = ""; 
            debt.Text = ""; 
            created.Text = DateTime.Now.ToString();
            addCustomerBorder.Visibility = Visibility.Visible;
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
            consumerService = new ConsumerService();
            if ((customerName.Text == "") || (address.Text == "") || (phone.Text == "") || (email.Text == "") || (debt.Text == "") || (created.Text == ""))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int Debt;
                DateTime Created;
                if (int.TryParse(debt.Text, out Debt) == false && DateTime.TryParse(created.Text, out Created) == false)
                {
                    debt.Text = "";
                    created.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (int.TryParse(debt.Text, out Debt) == false)
                {
                    debt.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (DateTime.TryParse(created.Text, out Created) == false)
                {
                    created.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (DateTime.TryParse(created.Text, out Created) && int.TryParse(debt.Text, out Debt))
                {
                    if (consumerService.AddConsumer(customerName.Text, address.Text, phone.Text, email.Text, Debt, Created))
                    {
                        MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadConsumers();
                        addCustomerBorder.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng đã tồn tại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }


        }

        private void closeBorder_addCustomer(object sender, RoutedEventArgs e)
        {
            addCustomerBorder.Visibility = Visibility.Hidden;
        }

        private void updateCustomer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {          
            consumerService = new ConsumerService();
            if (CustomersListView.SelectedItem is Consumer selectedConsumer)
            {
                updateCustomerBorder.Visibility = Visibility.Visible;
                customerName_update.Text = selectedConsumer.ConsumerName;
                address_update.Text = selectedConsumer.Address;
                phone_update.Text = selectedConsumer.Phone;
                email_update.Text = selectedConsumer.Email;
                debt_update.Text = selectedConsumer.Debt.ToString();
                created_update.Text = selectedConsumer.Created.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateCustomerBorder.Visibility = Visibility.Hidden;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            consumerService = new ConsumerService();
            if ((customerName_update.Text == "") || (address_update.Text == "") || (phone_update.Text == "") || (email_update.Text == "") || (debt_update.Text == "") || (created_update.Text ==""))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int Debt;
                DateTime Created;
                if (int.TryParse(debt_update.Text, out Debt) == false && DateTime.TryParse(created_update.Text, out Created) == false)
                {
                    debt_update.Text = "";
                    created_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (int.TryParse(debt_update.Text, out Debt) == false)
                {
                    debt_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (DateTime.TryParse(created_update.Text, out Created) == false)
                {
                    created_update.Text = "";
                    MessageBox.Show("Không được nhập sai kiểu dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                if (DateTime.TryParse(created_update.Text, out Created) && int.TryParse(debt_update.Text, out Debt))
                {
                    if (consumerService.UpdateConsumer(customerName_update.Text, address_update.Text, phone_update.Text, email_update.Text, Debt, Created))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadConsumers();

                        updateCustomerBorder.Visibility = Visibility.Hidden;
                    }
                    
                }
            }



        }

        private void searchText_DragEnter(object sender, DragEventArgs e)
        {
            
        }


        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (searchText.Text == "")
            {
                consumerService = new ConsumerService();
                LoadConsumers();
            }
            else
            {
                CustomersListView.ItemsSource = consumerService.SearchConsumerFromDB(searchText.Text);
            }
        }

        private void DebtCustomer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if(CustomersListView.SelectedItem is Consumer consumer)
            {
                consumerService = new ConsumerService();
                debtName.Text = consumer.ConsumerName;
                debtaddress.Text = consumer.Address;
                debtemail.Text = consumer.Email;
                debtphone.Text = consumer.Phone;
                debtcreated.Text = DateTime.Now.ToString();
                G_Debt = consumer.Debt;
                addDebtBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Chọn một khách hàng để thu tiền", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void closeBorder_debt(object sender, RoutedEventArgs e)
        {
            addDebtBorder.Visibility = Visibility.Hidden;
        }

        private void debt_Click(object sender, RoutedEventArgs e)
        {
            ConstraintsService = new ConstraintsService();
            int money;
            if(int.TryParse(debt_debt.Text, out money) == false)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                debt_debt.Text = "";
            }
            else if(debt_debt.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(ConstraintsService.GetConstraintValue("QĐ5") == "1" && money > G_Debt)
            {
                MessageBox.Show("Số tiền thu không vượt quá số tiền khách hàng đang nợ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                debt_debt.Text = "";
            }
            else
            {
                consumerService.UpdateConsumer(debtName.Text, debtaddress.Text, debtphone.Text, debtemail.Text, G_Debt-money, DateTime.Parse(debtcreated.Text));
                MessageBox.Show("Thu tiền thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadConsumers();
                addDebtBorder.Visibility = Visibility.Hidden;
            }
        }
    }
}
