using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Auth;
using Core.Auth.Interfaces;
using Core.Auth.ViewModels;

namespace Application.Auth.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository functionRepository;
        private readonly IMapper mapping;

        public FunctionService(IFunctionRepository functionRepository, IMapper mapping)
        {
            this.functionRepository = functionRepository;
            this.mapping = mapping;
        }

        public async Task<IEnumerable<FunctionDto>> GetFunctionsAsync()
        {
            var functions = await functionRepository.GetFunctionsAsync();
            var functionsDto = mapping.Map<IEnumerable<FunctionDto>>(functions);

            return functionsDto;
        }

        public async Task<FunctionDto> GetFunctionAsync(int id)
        {
            var function = await functionRepository.GetFunctionAsync(id);

            return mapping.Map<FunctionDto>(function);
        }

        public async Task<FunctionDto> DeleteFunctionAsync(int id)
        {
            var function = await functionRepository.DeleteFunctionAsync(id);
            return mapping.Map<FunctionDto>(function);
        }

        public async Task<FunctionDto> InsertFunctionAsync(NewFunctionDto functionDto)
        {
            var function = mapping.Map<NewFunctionDto, Function>(functionDto);
            function = await functionRepository.InsertAsync(function);

            return mapping.Map<FunctionDto>(function);
        }

        public async Task<FunctionDto> UpdateFunctionAsync(UpdateFunctionDto functionDto)
        {
            var function = mapping.Map<Function>(functionDto);
            function = await functionRepository.UpdateAsync(function);

            return mapping.Map<FunctionDto>(function);
        }
    }
}