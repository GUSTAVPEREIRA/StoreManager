using System.Collections.Generic;
using StoreManager.SharedKernel.ViewModels.Functions;

namespace StoreManager.SharedKernel.ViewModels.Users
{
    public class UpdateUserDTO
    {
        /// <example>1</example>
        public int Id { get; set; }

        /// <example>Senh@Segur@1</example>
        public string Password { get; set; }

        public ICollection<ReferenceFunctionDTO> Functions { get; set; }
    }
}