using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Inventory;
using Core.Inventory.Interface;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Inventory
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            foreach (var variant in product.Variants)
            {
                var optionIds = variant.Options.Select(s => s.Id).ToArray();
                var foundOptions = await context.Options.Where(w => optionIds.Contains(w.Id)).ToListAsync();

                variant.Options = foundOptions;
            }

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}