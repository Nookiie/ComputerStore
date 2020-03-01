using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("[action]")]
        public async Task<string> Submit(ShoppingCart cart)
        {
            try
            {
                return await service.Submit(cart);
            }
            catch (Exception e)
            {
                return "Could not submit order: " + e.StackTrace + e.Message;
            }
        }

        [HttpPost("[action]/{id}")]
        public async Task<string> SubmitByID(int id)
        {
            try
            {
                return await service.SubmitByID(id);
            }
            catch (Exception e)
            {
                return "Could not submit order: " + e.StackTrace + e.Message;
            }
        }
    }
}
