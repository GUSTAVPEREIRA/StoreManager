using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Domain;

namespace StoreManager.Core.Auth.Interfaces
{
    public interface IFunctionRepository
    {
        Task<Function> DeleteFunctionAsync(int id);
        Task<Function> GetFunctionAsync(int id);
        Task<IEnumerable<Function>> GetFunctionsAsync();
        Task<Function> InsertAsync(Function function);
        Task<Function> UpdateAsync(Function function);
    }
}