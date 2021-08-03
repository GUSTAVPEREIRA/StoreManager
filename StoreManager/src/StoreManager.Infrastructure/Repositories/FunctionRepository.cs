using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Infrastructure.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly StoreContext context;

        public FunctionRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Function>> GetFunctionsAsync()
        {
            return await context.Functions.AsNoTracking().ToListAsync();
        }

        public async Task<Function> GetFunctionAsync(int id)
        {
            return await context.Functions.FindAsync(id);
        }

        public async Task<Function> InsertAsync(Function function)
        {
            await context.Functions.AddAsync(function);
            await context.SaveChangesAsync();

            return function;
        }

        public async Task<Function> UpdateAsync(Function function)
        {
            var foundFunction = await context.Functions.FindAsync(function.Id);
            
            if (foundFunction == null)
            {
                return null;
            }

            context.Entry(foundFunction).CurrentValues.SetValues(function);
            await context.SaveChangesAsync();

            return foundFunction;
        }

        public async Task<bool> DeleteFunctionAsync(int id)
        {
            var foundFunction = await context.Functions.FindAsync(id);
            
            if (foundFunction == null)
            {
                return false;
            }

            context.Functions.Remove(foundFunction);
            await context.SaveChangesAsync();

            return true;
        }
    }
}