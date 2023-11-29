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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        EcommerceDBEntities EC;
        public ProductsPage()
        {
            InitializeComponent();
            EC = new EcommerceDBEntities();
            DG.ItemsSource = EC.Products.ToList();

        }

        private void Searchtext_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DG.ItemsSource = EC.Products.Where(x => x.Name.Contains(Searchtext.Text) || x.Description.Contains(Searchtext.Text) ).ToList();
        }

        private void IDtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantitytext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_buyNow_Click(object sender, RoutedEventArgs e)
        {
            if (IDtext.Text == "" || Quantitytext.Text == "")
                MessageBox.Show("please enter an ID and Quantity before Buy!");
            else
            {
                int theID = int.Parse(IDtext.Text);
                int theQuantity = int.Parse(Quantitytext.Text);
                Product p1 = EC.Products.FirstOrDefault(x => x.ProductID == theID);
                p1.StockQuantity -= theQuantity;
                EC.Products.AddOrUpdate(p1);
                EC.SaveChanges();

                OrderDetailsPage ordPage = new OrderDetailsPage(theID, theQuantity, p1.Price.Value);
                NavigationService.Navigate(ordPage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
