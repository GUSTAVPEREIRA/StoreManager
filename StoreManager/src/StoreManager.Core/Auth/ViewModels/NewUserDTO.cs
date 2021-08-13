using System.Collections.Generic;

namespace StoreManager.Core.Auth.ViewModels
{
    public class NewUserDTO : BaseUserDTO
    {        
        public ICollection<ReferenceFunctionDTO> Functions { get; set; }
    }
}