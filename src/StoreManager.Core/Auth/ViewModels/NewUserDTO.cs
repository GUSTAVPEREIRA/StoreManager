using System.Collections.Generic;

namespace StoreManager.Core.Auth.ViewModels
{
    public class NewUserDto : BaseUserDto
    {
        public ICollection<ReferenceFunctionDto> Functions { get; set; }
    }
}