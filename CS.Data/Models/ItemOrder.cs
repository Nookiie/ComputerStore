using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public decimal TotalPrice { get; set; }

        [DefaultValue(0)]
        public int PurchaseQuantity { get; set; }

        public ProductItem ProductItem { get; set; }

        [ForeignKey(nameof(ProductItem))]
        public int ProductItemID { get; set; }

    }
}
