using System;
using ComputerStore.Data.Models;
using ComputerStore.Data.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStore.Data.Models
{
    public class ProductItem : BaseModel<int>
    {
        public ProductItem()
        {

        }

        public ProductItem(string name, string description, int stockQuantity, decimal price, IList<Category> categories)
        {
            this.Name = name;
            this.Description = description;
            this.Quantity = stockQuantity;
            this.Price = price;
            this.CategoryObjects = categories;
        }

        [Required]
        [MaxLength(60, ErrorMessage = "Product Name is too long")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Product Description is too long")]
        public string Description { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        public decimal Price { get; set; }

        // Used for Unit Testing
        public IList<Category> CategoryObjects { get; set; } = new List<Category>();

        [NotMapped]
        public ICollection<string> Categories { get; set; }

        public ICollection<ProductItemCategory> ProductItemCategories { get; set; }
    }
}
