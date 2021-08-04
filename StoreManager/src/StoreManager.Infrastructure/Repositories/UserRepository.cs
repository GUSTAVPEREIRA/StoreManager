using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext context;
        public UserRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> InsertAsync(User user)
        {
            await InsertUserFunctionAsync(user);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task InsertUserFunctionAsync(User user)
        {
            var functions = new List<Function>();
            foreach (var function in user.Functions)
            {
                var foundFunction = await context.Functions.FindAsync(function.Id);
                functions.Add(foundFunction);
            }
            user.Functions = functions;
        }

        public async Task<Function> UpdateAsync(User user)
        {
            var foundUser = await context.Functions.FindAsync(user.Id);
            
            if (foundUser == null)
            {
                return null;
            }

            context.Entry(foundUser).CurrentValues.SetValues(user);
            await context.SaveChangesAsync();

            return foundUser;
        }
    }
}