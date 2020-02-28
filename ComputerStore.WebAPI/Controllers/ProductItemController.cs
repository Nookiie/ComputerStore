using ComputerStore.Data.Data;
using ComputerStore.Data.Models;

namespace ComputerStore.WebAPI.Controllers
{
    public class ProductItemController : GenericController<ProductItem>
    {
        public ProductItemController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
