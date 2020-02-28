using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class ItemOrderController : GenericController<ItemOrder>
    {
        public ItemOrderController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
