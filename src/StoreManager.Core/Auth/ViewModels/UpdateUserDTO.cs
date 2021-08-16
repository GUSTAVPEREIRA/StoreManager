using System.Collections.Generic;

namespace StoreManager.Core.Auth.ViewModels
{
    public class UpdateUserDto
    {
        /// <example>1</example>
        public int Id { get; set; }

        /// <example>Senh@Segur@1</example>
        public string Password { get; set; }

        public ICollection<ReferenceFunctionDto> Functions { get; set; }
    }
}