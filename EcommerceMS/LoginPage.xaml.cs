using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace EcommerceMS
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        EcommerceDBEntities db;
        CustomerProfilePage home;
        SellerPage sellerPage;
        public static int theCustomerID = 0;
        public LoginPage()
        {
            InitializeComponent();
            db = new EcommerceDBEntities();
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            int SelectedIndexInCompobox = compoBox1.SelectedIndex;// 0 -> user, 1 -> admin

            if (SelectedIndexInCompobox == 0)
            {
                //User Code
                var CustomerRec = db.Customers.FirstOrDefault(x => x.Name == txt_userName.Text && x.password == txt_password.Text);
                if (CustomerRec != null)
                {
                    theCustomerID = CustomerRec.CustomerID;
                    home = new CustomerProfilePage(theCustomerID);
                    this.NavigationService.Navigate(home);
                    txt_userName.Text = txt_password.Text = string.Empty;
                }
                else
                    MessageBox.Show("Wrong user name or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (SelectedIndexInCompobox == 1)
            {
                //Admin Code
                var adminRec = db.Sellers.FirstOrDefault(x => x.sellerName == txt_userName.Text && x.sellerPassword == txt_password.Text);
                if (adminRec != null)
                {
                    sellerPage = new SellerPage();
                    this.NavigationService.Navigate(sellerPage);

                    txt_Newpassword.Visibility = btn_saveNewPassword.Visibility = Visibility.Hidden;
                    txt_userName.Text = txt_password.Text = string.Empty;
                }
                else
                    MessageBox.Show("Wrong user name or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txt_userName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, TextChangedEventArgs e)
        {
        }


        private void compoBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_forgetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txt_userName.Text == "")
                MessageBox.Show("Please write User Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                txt_Newpassword.Visibility = btn_saveNewPassword.Visibility = Visibility.Visible;
            }
        }

        private void btn_singUp_Click(object sender, RoutedEventArgs e)
        {
            
            RegistrationPage signUpPage = new RegistrationPage();
            NavigationService.Navigate(signUpPage);
            
        }

        private void txt_Newpassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_saveNewPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Newpassword.Text == "")
                MessageBox.Show("Please write the New password before save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                /*
                 1- get record
                 2- update property
                 3- update the database
                 4- save changes
                 */
                Customer user = db.Customers.FirstOrDefault(x => x.Name == txt_userName.Text);
                user.password = txt_Newpassword.Text;
                user.Address = "";
                db.Customers.AddOrUpdate(user);
                db.SaveChanges();

                txt_Newpassword.Visibility = btn_saveNewPassword.Visibility = Visibility.Hidden;

            }

        }

        private void txt_password_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }
    }
}
