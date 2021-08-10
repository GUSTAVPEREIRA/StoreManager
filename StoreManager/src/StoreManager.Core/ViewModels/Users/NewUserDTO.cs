using System.Collections.Generic;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.Core.ViewModels.Users
{
    public class NewUserDTO : BaseUserDTO
    {        
        public ICollection<ReferenceFunctionDTO> Functions { get; set; }
    }
}