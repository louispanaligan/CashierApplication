using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApplication.ItemNameSpace
{
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
