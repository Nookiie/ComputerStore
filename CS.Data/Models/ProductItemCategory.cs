using ComputerStore.Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerStore.Data.Models
{
    public class ProductItemCategory : BaseModel<int>
    {
        public ProductItemCategory(int categoryID, int productID)
        {
            this.CategoryID = categoryID;
            this.ProductID = productID;
        }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        [ForeignKey(nameof(ProductItem))]
        public int ProductID { get; set; }

        public Category Category { get; set; }

        public ProductItem ProductItem { get; set; }
    }
}
