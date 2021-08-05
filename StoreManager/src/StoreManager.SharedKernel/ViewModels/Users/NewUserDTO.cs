using System.Collections.Generic;
using StoreManager.SharedKernel.ViewModels.Functions;

namespace StoreManager.SharedKernel.ViewModels.Users
{
    public class NewUserDTO
    {
        /// <example>CarlosSoares</example>
        public string Login { get; set; }

        /// <example>senh@Segur@</example>
        public string Password { get; set; }
        public ICollection<ReferenceFunctionDTO> Functions { get; set; }
    }
}