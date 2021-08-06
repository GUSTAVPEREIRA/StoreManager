using Microsoft.EntityFrameworkCore;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Repositories.UnitTests
{
    public static class InitializeMemoryContext
    {
        public static StoreContext Initialize(string nameDBBugado)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseInMemoryDatabase(nameDBBugado);
            return new StoreContext(optionsBuilder.Options);
        }
    }
}