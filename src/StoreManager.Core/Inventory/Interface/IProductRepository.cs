using System.Threading.Tasks;

namespace StoreManager.Core.Inventory.Interface
{
    public interface IProductRepository
    {
        Task<Product> InsertProductAsync(Product product);
    }
}