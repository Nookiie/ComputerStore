using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Models.Abstract
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
