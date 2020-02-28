using ComputerStore.Data.Data;
using ComputerStore.Data.Models;

namespace ComputerStore.WebAPI.Controllers
{
    public class ItemOrderController : GenericController<ItemOrder>
    {
        public ItemOrderController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
