using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class ProductItemsController : GenericController<ProductItem>
    {
        public ProductItemsController(ComputerStoreDbContext context) : base(context)
        {
            service = new ProductItemService(context);
        }

        ProductItemService service;

        [HttpPost("[action]")]
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
    }
}
