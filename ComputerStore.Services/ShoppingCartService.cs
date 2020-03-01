using ComputerStore.Common;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class ShoppingCartService : GenericService<ShoppingCart>
    {
        public ShoppingCartService(ComputerStoreDbContext context) : base(context)
        {
            itemOrderService = new ItemOrderService(context);
            productItemService = new ProductItemService(context);
            productItemCategoryService = new GenericService<ProductItemCategory>(context);
            categoryService = new GenericService<Category>(context);
        }

        private ItemOrderService itemOrderService;
        private ProductItemService productItemService;
        private GenericService<ProductItemCategory> productItemCategoryService;
        private GenericService<Category> categoryService;

        public async Task<string> Submit(ShoppingCart cart)
        {
            if (!(AllAsNoTracking().Select(x => x.ID).Contains(cart.ID)))
            {
                return "Cart could not be found in DB";
            }

            await SetShoppingCart(cart);

            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);
            await Update(cart);

            return ShoppingCartUtils.DebugMessages.Any() 
                ? string.Join("\n", ShoppingCartUtils.DebugMessages)
                : "No discounts applied \nCart's TotalValue updated";
        }

        public async Task<string> SubmitByID(int id)
        {
            var cart = All().FirstOrDefault(x => x.ID == id);

            if (cart == null)
            {
                return "Cart could not be found in DB";
            }

            return await Submit(cart);
        }

        // Loading all object values into the cart's corresponding entities 
        private async Task SetShoppingCart(ShoppingCart cart)
        {
            var itemOrders = itemOrderService.All()
                .Where(x => x.ShoppingCartID == cart.ID)
                .ToList();

            foreach (var itemOrder in itemOrders)
            {
                itemOrder.ProductItem = await productItemService.GetByID(itemOrder.ProductItemID);
                var productItemCategories = productItemCategoryService.All()
                    .Where(x => x.ProductID == itemOrder.ProductItemID);

                foreach (var productItemCategory in productItemCategories)
                {
                    var category = await categoryService.GetByID(productItemCategory.CategoryID);
                    itemOrder.ProductItem.CategoryObjects.Add(category);
                }

                itemOrder.ShoppingCart = cart;
            }

            cart.ItemOrders = itemOrders;
        }
    }
}
