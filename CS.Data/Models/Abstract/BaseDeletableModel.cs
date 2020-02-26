using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Models.Abstract
{
    // For Soft Delete Functionality
    public class BaseDeletableModel
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
