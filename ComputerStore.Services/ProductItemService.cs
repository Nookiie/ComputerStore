using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach (var categoryString in product.Categories)
            {
                await categoryService.Create(new Category(categoryString, ""));
            }

            await base.Create(product);

            // Assigning foreign keys in many-many table
            foreach (var categoryString in product.Categories)
            {
                var category = categoryService.All().FirstOrDefault(x => x.Name == categoryString);

                if (category == null)
                {
                    break;
                }

                await productItemCategoryService.Create(new ProductItemCategory(category.ID, product.ID));
            }

            return product;
        }
    }
}
