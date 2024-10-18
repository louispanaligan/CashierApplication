using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierApplication.ItemNameSpace
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
    }


