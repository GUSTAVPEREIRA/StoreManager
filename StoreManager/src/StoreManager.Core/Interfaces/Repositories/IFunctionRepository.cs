using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Domain;

namespace StoreManager.Core.Interfaces.Repositories
{
    public interface IFunctionRepository
    {
        Task<bool> DeleteFunctionAsync(int id);
        Task<Function> GetFunctionAsync(int id);
        Task<IEnumerable<Function>> GetFunctionsAsync();
        Task<Function> InsertAsync(Function function);
        Task<Function> UpdateAsync(Function function);
    }
}