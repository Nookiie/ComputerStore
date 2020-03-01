using ComputerStore.Data.Data;
using ComputerStore.Data.Models;

namespace ComputerStore.WebAPI.Controllers
{
    public class ItemOrdersController : GenericController<ItemOrder>
    {
        public ItemOrdersController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
