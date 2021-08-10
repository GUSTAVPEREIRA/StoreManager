using System.Collections.Generic;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.Core.ViewModels.Users
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