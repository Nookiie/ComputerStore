using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class ShoppingCartService : GenericService<ShoppingCart>
    {
        public ShoppingCartService(ComputerStoreDbContext context) : base(context)
        {

        }

        public async Task<string> ApplyDiscount(ShoppingCart cart)
        {
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);
            await Update(cart);

            return string.Join(", ", ShoppingCartUtils.DebugMessages);
        }
    }
}
