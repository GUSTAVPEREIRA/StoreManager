using System.Threading.Tasks;

namespace Core.Inventory.Interface
{
    public interface IProductRepository
    {
        Task<Product> InsertProductAsync(Product product);
    }
}