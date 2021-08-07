using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.Core.Interfaces.Services
{
    public interface IFunctionService
    {
        Task<FunctionDTO> DeleteFunctionAsync(int id);
        Task<FunctionDTO> GetFunctionAsync(int id);        
        Task<IEnumerable<FunctionDTO>> GetFunctionsAsync();
        Task<FunctionDTO> InsertFunctionAsync(NewFunctionDTO functionDTO);
        Task<FunctionDTO> UpdateFunctionAsync(UpdateFunctionDTO functionDTO);
    }
}