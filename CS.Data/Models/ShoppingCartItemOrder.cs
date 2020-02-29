using ComputerStore.Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerStore.Data.Models
{
    public class ShoppingCartItemOrder : BaseModel<int>
    {
        [ForeignKey(nameof(ShoppingCart))]
        public int ShoppingCartID { get; set; }

        [ForeignKey(nameof(ItemOrder))]
        public int ItemOrderID { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public ItemOrder ItemOrder { get; set; }
    }
}
