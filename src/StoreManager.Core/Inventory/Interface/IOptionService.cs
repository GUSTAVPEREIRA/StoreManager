using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.Core.Inventory.Interface
{
    public interface IOptionService
    {
        Task<OptionDto> UpdateOptionAsync(OptionDto optionDto);
        Task<OptionDto> GetOptionAsync(int id);
        Task<IEnumerable<OptionDto>> GetOptionsAsync();
        Task DeleteOptionAsync(int id);
        Task<OptionDto> InsertOptionAsync(NewOptionDto newOptionDto);
    }
}