using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ComputerStore.Data.Models.Abstract;

namespace ComputerStore.Data.Models
{
    public class ShoppingCart : BaseModel<int>
    {
        public ShoppingCart()
        {
            
        }

        public ShoppingCart(ICollection<ItemOrder> Orders)
        {
            this.ItemOrders = Orders;
        }

        public ICollection<ItemOrder> ItemOrders { get; set; } = new List<ItemOrder>();

        public decimal TotalPrice { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public bool IsValid { get; set; } = true;
    }
}
