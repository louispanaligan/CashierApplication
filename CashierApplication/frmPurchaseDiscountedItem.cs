using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        public frmPurchaseDiscountedItem()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmPurchaseDiscountedItem_Load(object sender, EventArgs e)
        {
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double price = Convert.ToDouble(txtPrice.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);

                ItemNamespace.DiscountedItem item = new ItemNamespace.DiscountedItem(price, quantity, discount);

                double totalAmount = item.CalculateTotal();

                lblTotal.Text = "Total Amount: $" + totalAmount.ToString("F2");
                lblChange.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDiscount.Clear();
            txtPayment.Clear();
            lblTotal.Text = "Total: 0.00";
            lblChange.Text = "Change: $0.00";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                double payment = Convert.ToDouble(txtPayment.Text);
                double totalAmount = Convert.ToDouble(lblTotal.Text.Replace("Total Amount: $", ""));

                double change = payment - totalAmount;

                lblChange.Text = "Change: $" + change.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
        }
    }
         namespace ItemNamespace
    {
        public class Item
        {
            public double Price { get; set; }
            public int Quantity { get; set; }

            public Item(double price, int quantity)
            {
                Price = price;
                Quantity = quantity;
            }

            public virtual double CalculateTotal()
            {
                return Price * Quantity;
            }
        }

        public class DiscountedItem : Item
        {
            public double Discount { get; set; }

            public DiscountedItem(double price, int quantity, double discount)
                : base(price, quantity)
            {
                Discount = discount;
            }

            public override double CalculateTotal()
            {
                double discountAmount = Price * (Discount * 0.01);
                double discountedPrice = Price - discountAmount;
                return discountedPrice * Quantity;
            }
        }


    }
}
    

