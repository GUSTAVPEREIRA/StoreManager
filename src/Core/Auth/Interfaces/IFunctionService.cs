using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Auth.ViewModels;

namespace Core.Auth.Interfaces
{
    public interface IFunctionService
    {
        Task<FunctionDto> DeleteFunctionAsync(int id);
        Task<FunctionDto> GetFunctionAsync(int id);
        Task<IEnumerable<FunctionDto>> GetFunctionsAsync();
        Task<FunctionDto> InsertFunctionAsync(NewFunctionDto functionDto);
        Task<FunctionDto> UpdateFunctionAsync(UpdateFunctionDto functionDto);
    }
}