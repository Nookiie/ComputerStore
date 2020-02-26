using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ComputerStore.Data.Models.Abstract;

namespace ComputerStore.Data.Models
{
    public class Category : BaseModel<int>
    {
        public Category(string name,  string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int SubcategoryID { get; set; }
    }
}
