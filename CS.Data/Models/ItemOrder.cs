using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ComputerStore.Data.Models.Abstract;

namespace ComputerStore.Data.Models
{
    public class ItemOrder : BaseModel<int>
    {
        public ItemOrder()
        {

        }

        public ItemOrder(ProductItem item, int purchaseQuantity)
        {
            this.ProductItem = item;
            this.PurchaseQuantity = purchaseQuantity;
            TotalPrice = item.Price * PurchaseQuantity;
        }

        [DefaultValue(0)]
        public decimal TotalPrice { get; set; } = 0;

        [DefaultValue(1)]
        public int PurchaseQuantity { get; set; }

        public ProductItem ProductItem { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        [Required, ForeignKey(nameof(ProductItem))]
        public int ProductItemID { get; set; }

        [Required, ForeignKey(nameof(ShoppingCart))]
        public int ShoppingCartID { get; set; }

    }
}
