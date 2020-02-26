using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ComputerStore.Data.Models.Abstract;

namespace ComputerStore.Data.Models
{
    // It's a good idea for the shopping cart to inherit BaseModel,
    // would help later on with troubleshooting client transaction errors
    public class ShoppingCart : BaseModel<int>
    {
        public ShoppingCart()
        {
            
        }

        public ShoppingCart(ICollection<ItemOrder> Orders)
        {
            this.Orders = Orders;
        }

        public ICollection<ItemOrder> Orders { get; set; } = new List<ItemOrder>();

        public decimal TotalPrice { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public bool IsValid { get; set; } = true;
    }
}
