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
    /// Interaction logic for OrderDetailsPage.xaml
    /// </summary>
    public partial class OrderDetailsPage : Page
    {
        EcommerceDBEntities db;
        int prodID, Quantity, price = 0;
        public OrderDetailsPage(int _prodID, int _Quantity, int _price)
        {
            InitializeComponent();
            db = new EcommerceDBEntities();
            this.prodID = _prodID;
            this.Quantity = _Quantity;
            price = _price;
            productGrid.ItemsSource = db.Products.Where(x => x.ProductID == prodID).ToList();
            orderAssign();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void orderAssign()
        {
            Order_table order = new Order_table();
            int newOrderID = db.Order_table.Max(x => x.OrderID) + 1;

            order.OrderID = newOrderID;
            order.CustomerID = LoginPage.theCustomerID;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = Quantity * price;
            db.Order_table.Add(order);
            db.SaveChanges();

            orderGrid.ItemsSource = db.Order_table.Where(x => x.OrderID == newOrderID).ToList();
            OrderDetailsAssign(newOrderID);
        }

        private void OrderDetailsAssign(int newOrderID)
        {
            Order_Details _Details = new Order_Details();
            int newOrderDetilsID = db.Order_Details.Max(x => x.OrderDetailID) + 1;

            _Details.OrderDetailID = newOrderDetilsID;
            _Details.ProductID = prodID;
            _Details.OrderID = newOrderID;
            _Details.Quantity = Quantity;
            _Details.UnitPrice = price;

            db.Order_Details.Add(_Details);
            db.SaveChanges();

            orderDetialsGrid.ItemsSource = db.Order_Details.Where(x => x.OrderDetailID == newOrderDetilsID).ToList();
        }
    }
}
