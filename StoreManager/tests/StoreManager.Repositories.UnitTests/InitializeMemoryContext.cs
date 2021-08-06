using Microsoft.EntityFrameworkCore;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Repositories.UnitTests
{
    public static class InitializeMemoryContext
    {
        public static StoreContext Initialize()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseInMemoryDatabase("DBTest");
            return new StoreContext(optionsBuilder.Options);
        }
    }
}