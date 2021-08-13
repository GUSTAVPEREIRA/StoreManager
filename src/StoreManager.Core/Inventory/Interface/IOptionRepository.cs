using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManager.Core.Inventory.Interface
{
    public interface IOptionRepository
    {
        Task<Option> InsertOptionAsync(Option option);
        Task<Option> UpdateOptionAsync(Option option);
        Task<Option> GetOptionAsync(int id);
        Task<IEnumerable<Option>> GetOptionsAsync();
        Task DeleteOptionAsync(int id);
    }
}