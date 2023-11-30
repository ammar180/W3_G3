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
    /// Interaction logic for SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {
        EcommerceDBEntities Ed = new EcommerceDBEntities();

        public SellerPage()
        {
            InitializeComponent();
            Product_Grid.ItemsSource = Ed.Products.ToList();

        }

        private void textbox_id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_Dec_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_Qunitit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_Price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_id.Text != "")
            {
                MessageBox.Show("Id is Atumatic");

            }
            Product pro = new Product();
            pro.Name = textbox_id.Text;
            pro.ProductID = int.Parse(textbox_id.Text);
            pro.Description = textbox_id.Text;
            pro.Price = int.Parse(textbox_Price.Text);
            pro.StockQuantity = int.Parse(textbox_Qunitit.Text);

            Ed.Products.Add(pro);
            Ed.SaveChanges();

            MessageBox.Show("Data save Sucsessfull");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product p1 = new Product();
            int depo = int.Parse(textbox_id.Text);
            p1 = Ed.Products.FirstOrDefault(x => x.ProductID == depo);
            p1.Name = textbox_id.Text;
            p1.Price = int.Parse(textbox_Price.Text);
            p1.Description = textbox_id.Text;
            p1.StockQuantity = int.Parse(textbox_Qunitit.Text);
            Ed.Products.AddOrUpdate(p1);
            Ed.SaveChanges();
            MessageBox.Show("Go ahead");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int poe = int.Parse(textbox_id.Text);
            Product peo = Ed.Products.Remove(Ed.Products.First(x => x.ProductID == poe));
            MessageBox.Show("done delete");
            Ed.SaveChanges();
        }
    }
}
