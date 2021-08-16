using Microsoft.EntityFrameworkCore;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Repositories.UnitTests
{
    public static class InitializeMemoryContext
    {
        public static StoreContext Initialize(string name)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseInMemoryDatabase(name);
            return new StoreContext(optionsBuilder.Options);
        }
    }
}