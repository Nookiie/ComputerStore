using System;
using ComputerStore.Data.Models;
using ComputerStore.Data.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComputerStore.Data.Models
{
    public class ProductItem : BaseModel<int>
    {
        public ProductItem()
        {

        }

        public ProductItem(string name, string description, int stockQuantity, decimal price, ICollection<Category> categories)
        {
            this.Name = name;
            this.Description = description;
            this.StockQuantity = stockQuantity;
            this.Price = price;
            this.Categories = categories;
        }

        [Required]
        [MaxLength(60, ErrorMessage = "Product Name is too long")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Product Description is too long")]
        public string Description { get; set; }

        [DefaultValue(0)]
        public int StockQuantity { get; set; }

        [DefaultValue(0)]
        public decimal Price { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
