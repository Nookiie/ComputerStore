using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class ItemOrderService : GenericService<ItemOrder>
    {
        public ItemOrderService(ComputerStoreDbContext context) : base(context)
        {

        }

        public override async Task<ItemOrder> Create(ItemOrder entity)
        {
            SetItemOrder(entity);

            return await base.Create(entity);
        }

        public override async Task Update(ItemOrder entity)
        {
            SetItemOrder(entity);

            await base.Update(entity);
        }

        private void SetItemOrder(ItemOrder entity)
        {
            if (entity.PurchaseQuantity <= 0)
            {
                entity.PurchaseQuantity = 1;
            }


        }
    }
}
