using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StoreManager.Core.Inventory;
using StoreManager.Core.Inventory.Interface;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.Application.Inventory.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository optionRepository;
        private readonly IMapper mapper;

        public OptionService(IOptionRepository optionRepository, IMapper mapper)
        {
            this.optionRepository = optionRepository;
            this.mapper = mapper;
        }

        public async Task<OptionDto> UpdateOptionAsync(OptionDto optionDto)
        {
            var option = mapper.Map<Option>(optionDto);
            option = await optionRepository.UpdateOptionAsync(option);
            return mapper.Map<OptionDto>(option);
        }

        public async Task<OptionDto> GetOptionAsync(int id)
        {
            var option = await optionRepository.GetOptionAsync(id);
            return mapper.Map<OptionDto>(option);
        }

        public async Task<IEnumerable<OptionDto>> GetOptionsAsync()
        {
            var options = await optionRepository.GetOptionsAsync();
            return mapper.Map<IEnumerable<OptionDto>>(options);
        }

        public async Task DeleteOptionAsync(int id)
        {
            await optionRepository.DeleteOptionAsync(id);
        }

        public async Task<OptionDto> InsertOptionAsync(NewOptionDto newOptionDto)
        {
            var option = mapper.Map<Option>(newOptionDto);
            option = await optionRepository.InsertOptionAsync(option);
            return mapper.Map<OptionDto>(option);
        }
    }
}