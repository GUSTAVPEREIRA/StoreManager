using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StoreManager.Core.Domain;
using StoreManager.Core.Interfaces.Repositories;
using StoreManager.Core.Interfaces.Services;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.Core.Services
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

        public async Task<IEnumerable<FunctionDTO>> GetFunctionsAsync()
        {

            var functions = await functionRepository.GetFunctionsAsync();
            var funcionsDTO = mapping.Map<IEnumerable<FunctionDTO>>(functions);

            return funcionsDTO;
        }

        public async Task<FunctionDTO> GetFunctionAsync(int id)
        {
            var function = await functionRepository.GetFunctionAsync(id);

            return mapping.Map<FunctionDTO>(function);
        }

        public async Task<FunctionDTO> DeleteFunctionAsync(int id)
        {
            var function = await functionRepository.DeleteFunctionAsync(id);
            return mapping.Map<FunctionDTO>(function);
        }

        public async Task<FunctionDTO> InsertFunctionAsync(NewFunctionDTO functionDTO)
        {
            var function = mapping.Map<NewFunctionDTO, Function>(functionDTO);
            function = await functionRepository.InsertAsync(function);

            return mapping.Map<FunctionDTO>(function);
        }

        public async Task<FunctionDTO> UpdateFunctionAsync(UpdateFunctionDTO functionDTO)
        {
            var function = mapping.Map<Function>(functionDTO);
            function = await functionRepository.UpdateAsync(function);

            return mapping.Map<FunctionDTO>(function);
        }
    }
}