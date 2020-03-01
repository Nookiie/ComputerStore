using ComputerStore.Data.Data;
using ComputerStore.Data.Models;

namespace ComputerStore.WebAPI.Controllers
{
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
