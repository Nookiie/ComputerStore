using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class ShoppingCartsController : GenericController<ShoppingCart>
    {
        public ShoppingCartsController(ComputerStoreDbContext context) : base(context)
        {
            service = new ShoppingCartService(context);
        }

        private ShoppingCartService service;

        public async Task<string> Submit(ShoppingCart cart)
        {
            try
            {
                await service.Submit(cart);
                return "Order successfully submitted";
            }
            catch (Exception e)
            {
                return "Could not submit order: " + e.StackTrace + e.Message;
            }
        }
    }
}
