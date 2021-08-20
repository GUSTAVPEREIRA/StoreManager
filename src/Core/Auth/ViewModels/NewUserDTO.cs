using System.Collections.Generic;

namespace Core.Auth.ViewModels
{
    public class NewUserDto : BaseUserDto
    {
        public ICollection<ReferenceFunctionDto> Functions { get; set; }
    }
}