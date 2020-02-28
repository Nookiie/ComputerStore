using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using System;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class ProductItemController : GenericController<ProductItem>
    {
        public ProductItemController(ComputerStoreDbContext context) : base(context)
        {
            service = new ProductItemService(context);
        }

        ProductItemService service;

        public override async Task<string> Create(ProductItem entity)
        {
            try
            {
                await service.Create(entity);
                return "Entity has been saved to DB";
            }
            catch (Exception e)
            {
                return "Entity could not be saved to DB, Stack Trace: " + e.StackTrace + " " + e.Message;
            }
        }

        // Default Directory for Importing
        public async Task<string> ImportJSON()
        {
            return "sdada";
        }
    }
}
