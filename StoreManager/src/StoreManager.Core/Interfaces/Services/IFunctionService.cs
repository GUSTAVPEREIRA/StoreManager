using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.SharedKernel.ViewModels;

namespace e.Interfaces.Services
{
    public interface IFunctionService
    {
        Task DeleteFunctionAsync(int id);
        Task<FunctionDTO> GetFunctionAsync(int id);        
        Task<IEnumerable<FunctionDTO>> GetFunctionsAsync();
        Task<FunctionDTO> InsertFunctionAsync(NewFunctionDTO functionDTO);
        Task<FunctionDTO> UpdateFunctionAsync(UpdateFunctionDTO functionDTO);
    }
}