using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Data.Models.Abstract
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
