using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MaxLength(60, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description is too long")]
        public string Description { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int SubcategoryID { get; set; }
    }
}
