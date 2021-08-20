using System;
using System.Collections.Generic;

namespace Core.Auth.ViewModels
{
    public class UserDto
    {
        public UserDto()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <example>1</example>
        public int Id { get; set; }

        /// <example>CarlosRoberto</example>
        public string Login { get; set; }

        public ICollection<FunctionDto> Functions { get; set; }

        /// <example>05/08/2021 or null</example>
        public DateTime? LastAccess { get; set; }

        /// <example>20/07/1992</example>
        public DateTime CreatedAt { get; private set; }

        /// <example>20/07/1994 OR null</example>
        public DateTime? UpdatedAt { get; set; }

        /// <example>20/07/1998 or null</example>
        public DateTime? DeletedAt { get; set; }
    }
}