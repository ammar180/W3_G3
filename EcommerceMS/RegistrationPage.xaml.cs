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

namespace EcommerceMS
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        EcommerceDBEntities db;
        bool status = false;
        public RegistrationPage()
        {
            InitializeComponent();
            db = new EcommerceDBEntities();

        }

        private void btn_singUp_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            try
            {
                if (txt_userName.Text == "" || txt_password.Text == "")
                    MessageBox.Show("Sorry please defin User name and password befor sign up");
                if (status == false)
                    MessageBox.Show("write a strong password");

                else
                {
                    customer.CustomerID = db.Customers.Max(cid => cid.CustomerID) + 1;
                    customer.Name = txt_userName.Text;
                    customer.password = txt_password.Text;
                    customer.Address = txt_address.Text;
                    customer.Phone = txt_phone.Text;
                    customer.Email = txt_email.Text;

                    db.Customers.Add(customer);
                    db.SaveChanges();

                    txt_userName.Text = txt_email.Text = txt_password.Text = txt_phone.Text = txt_address.Text = string.Empty;
                    MessageBox.Show("User Registar Successfuly!");

                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_userName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_password_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string thePassword = txt_password.Text;

            bool hasLetters = false,
                hasDegit = false,
                hasSpecialCharactirs = false;
            foreach (char c in thePassword)
            {
                if (char.IsLetter(c))
                {
                    hasLetters = true;
                    lab_ContainLetters.Foreground = Brushes.Green;
                }
                if (char.IsDigit(c))
                {
                    hasDegit = true;
                    lab_ContainDigits.Foreground = Brushes.Green;
                }
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialCharactirs = true;
                    lab_ContainSpec.Foreground = Brushes.Green;
                }
            }
            if (thePassword.Length > 4 && hasLetters && hasDegit && hasSpecialCharactirs)
            {
                status = true;
                lab_MoreThan5Chars.Foreground = Brushes.Green;
            }



            btn_signUp.IsEnabled = status;
        }

        private void txt_email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_address_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_forgetPassword_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            NavigationService.Navigate(loginPage);
        }
    }
}
