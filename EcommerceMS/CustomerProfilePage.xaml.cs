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
    /// Interaction logic for CustomerProfilePage.xaml
    /// </summary>
    public partial class CustomerProfilePage : Page
    {
        int CustomerID;
        public CustomerProfilePage(int _CustomerID)
        {
            InitializeComponent();
            CustomerID = _CustomerID;
            customerDetailsSetter();
        }

        private void customerDetailsSetter()
        {
            EcommerceDBEntities db = new EcommerceDBEntities();
            Customer customer = new Customer();
            customer = db.Customers.FirstOrDefault(x => x.CustomerID == CustomerID);
            lab_custID.Content += customer.CustomerID.ToString();
            lab_custName.Content += customer.Name;
            lab_custEmail.Content += customer.Email;
            lab_custAddress.Content += customer.Address;
            lab_custPhone.Content += customer.Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productPage = new ProductsPage();
            this.NavigationService.Navigate(productPage);
        }
    }
}
