using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;

namespace Repositories.UnitTests
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