using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using System;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class ItemOrdersController : GenericController<ItemOrder>
    {
        public ItemOrdersController(ComputerStoreDbContext context) : base(context)
        {
            service = new ItemOrderService(context);
        }

        private ItemOrderService service;

        public override async Task<string> Create(ItemOrder entity)
        {
            try
            {
                await service.Create(entity);
                return GlobalConstants.DB_ENTITY_ADD_SUCCESS;
            }
            catch (Exception e)
            {
                return GlobalConstants.DB_ENTITY_ADD_FAIL + e.StackTrace + e.Message;
            }
        }
    }
}
