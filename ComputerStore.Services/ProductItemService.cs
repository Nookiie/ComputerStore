using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class ProductItemService : GenericService<ProductItem>
    {
        public ProductItemService(ComputerStoreDbContext context) : base(context)
        {
            categoryService = new GenericService<Category>(context);
            productItemCategoryService = new GenericService<ProductItemCategory>(context);
        }

        GenericService<Category> categoryService;
        GenericService<ProductItemCategory> productItemCategoryService;

        public async override Task<ProductItem> Create(ProductItem product)
        {
            foreach (var category in product.Categories)
            {
                await categoryService.Create(category);
            }

            await base.Create(product);

            foreach(var category in product.Categories)
            {
                await productItemCategoryService.Create(new ProductItemCategory(category.ID, product.ID));
            }

            return product;
        }
    }
}
