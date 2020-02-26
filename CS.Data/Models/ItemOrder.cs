using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Data.Models.Abstract;

namespace ComputerStore.Data.Models
{
    public class ItemOrder : BaseModel<int>
    {
        public ItemOrder(ProductItem item, int PurchaseQuantity)
        {
            TotalPrice = ProductItem.Price * PurchaseQuantity;
        }

        public ProductItem ProductItem { get; set; }

        public decimal TotalPrice { get; set; }

        public int PurchaseQuantity { get; set; }
    }
}
