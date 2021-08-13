using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Inventory;
using StoreManager.Core.Inventory.Interface;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Infrastructure.Repositories.Inventory
{
    public class OptionRepository : IOptionRepository
    {
        private readonly StoreContext context;

        public OptionRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Option> InsertOptionAsync(Option option)
        {
            await context.Options.AddAsync(option);
            await context.SaveChangesAsync();
            return option;
        }

        public async Task<Option> UpdateOptionAsync(Option option)
        {
            var foundOption = await context.Options.FindAsync(option.Id);

            if (foundOption == null)
            {
                return null;
            }

            context.Entry(foundOption).CurrentValues.SetValues(option);
            await context.SaveChangesAsync();
            return foundOption;
        }

        public async Task<Option> GetOptionAsync(int id)
        {
            var foundOption = await context.Options.SingleOrDefaultAsync(x => x.Id == id);

            return foundOption;
        }

        public async Task<IEnumerable<Option>> GetOptionsAsync()
        {
            var foundOptions = await context.Options.ToListAsync();
            return foundOptions;
        }

        public async Task DeleteOptionAsync(int id)
        {
            var foundOption = await context.Options.FindAsync(id);

            context.Options.Remove(foundOption);
            await context.SaveChangesAsync();
        }
    }
}