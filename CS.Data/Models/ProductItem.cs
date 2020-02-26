using System;
using ComputerStore.Data.Models;
using ComputerStore.Data.Models.Abstract;
using System.Collections.Generic;

namespace ComputerStore.Data.Models
{
    public class ProductItem : BaseModel<int>
    {
        public ProductItem(string name, string description, int stockQuantity, decimal price, ICollection<Category> categories)
        {
            this.Name = name;
            this.Description = description;
            this.StockQuantity = stockQuantity;
            this.Price = price;
            this.Categories = categories;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
