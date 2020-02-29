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
    public class ShoppingCartController : GenericController<ShoppingCart>
    {
        public ShoppingCartController(ComputerStoreDbContext context) : base(context)
        {
            service = new ShoppingCartService(context);
        }

        private ShoppingCartService service;

        public async Task<string> ApplyDiscount(ShoppingCart cart) => await service.ApplyDiscount(cart);
    }
}
