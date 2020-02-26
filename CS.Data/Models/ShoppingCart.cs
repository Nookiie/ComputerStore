using System;
using System.Collections.Generic;
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

            foreach (var item in Orders)
            {
                if (item.PurchaseQuantity > item.ProductItem.StockQuantity)
                {
                    IsValid = false;
                    // Debug.Error("Error, PurchaseQuantity is larger than StockQuantity of Item: {0}", item.ProductItem.Name);
                    return;
                }

                TotalPrice += item.TotalPrice;
                // DiscountCalculator
            }
        }

        public ICollection<ItemOrder> Orders { get; set; }

        public decimal TotalPrice { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public bool IsValid { get; set; } = true;
    }
}
