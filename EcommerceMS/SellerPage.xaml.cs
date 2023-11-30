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
        EcommerceDBEntities entities = new EcommerceDBEntities();

        public SellerPage()
        {
            InitializeComponent();
            Product_Grid.ItemsSource = entities.Products.ToList();

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
            if (txt_productID.Text != "")
            {
                MessageBox.Show("Id is Atumatic");

            }
            Product pro = new Product();
            pro.ProductID = entities.Products.Max(x => x.ProductID) + 1;
            pro.Name = txt_name.Text;
            pro.ProductID = int.Parse(txt_productID.Text);
            pro.Description = txt_des.Text;
            pro.Price = int.Parse(textbox_Price.Text);
            pro.StockQuantity = int.Parse(textbox_Qunitit.Text);

            entities.Products.Add(pro);
            entities.SaveChanges();

            MessageBox.Show("Data save Sucsessfull");
            Product_Grid.ItemsSource = entities.Products.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txt_productID == null)
                MessageBox.Show("please select an ID before update");
            else
            {
                int theID = int.Parse(txt_productID.Text);
                var prod = entities.Products.FirstOrDefault(x => x.ProductID == theID);
                if (textbox_Price.Text != string.Empty)
                    prod.Price = int.Parse(textbox_Price.Text);
                if (txt_name.Text != string.Empty)
                    prod.Name = txt_name.Text;
                if (txt_des.Text != string.Empty)
                    prod.Description = txt_des.Text;
                if (textbox_Qunitit.Text != string.Empty)
                    prod.StockQuantity = int.Parse(textbox_Qunitit.Text);

                entities.Products.AddOrUpdate(prod);
                entities.SaveChanges();
                MessageBox.Show("Data Updated Successfully!");
                Product_Grid.ItemsSource = entities.Products.ToList();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int poe = int.Parse(txt_productID.Text);
            Product peo = entities.Products.Remove(entities.Products.First(x => x.ProductID == poe));
            MessageBox.Show("done delete");
            entities.SaveChanges();
            Product_Grid.ItemsSource = entities.Products.ToList();
        }
    }
}
