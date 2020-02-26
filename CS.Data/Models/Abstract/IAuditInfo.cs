using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Models.Abstract
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
