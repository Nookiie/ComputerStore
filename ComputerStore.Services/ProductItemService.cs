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

        protected readonly GenericService<Category> categoryService;
        protected readonly GenericService<ProductItemCategory> productItemCategoryService;
        
        public async override Task<ProductItem> Create(ProductItem product)
        {
            var categoryStringList = product.Categories.ToList();
            for (int i = 0; i < product.Categories.Count; i++)
            {
                categoryStringList[i] = categoryStringList[i].Replace(" ", "");
            }

            foreach (var categoryString in categoryStringList)
            {
                if (categoryService.All().Any(x => x.Name == categoryString))
                {
                    continue;
                }

                await categoryService.Create(new Category(categoryString, ""));
            }

            await base.Create(product);

            // Assigning foreign keys in many-many table
            foreach (var categoryString in categoryStringList)
            {
                var category = categoryService.All().FirstOrDefault(x => x.Name == categoryString);

                if (category == null)
                {
                    continue;
                }

                await productItemCategoryService.Create(new ProductItemCategory(category.ID, product.ID));
            }

            return product;
        }
    }
}
