using ComputerStore.Data.Data;
using ComputerStore.Data.Models;

namespace ComputerStore.WebAPI.Controllers
{
    public class CategoryController : GenericController<Category>
    {
        public CategoryController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
