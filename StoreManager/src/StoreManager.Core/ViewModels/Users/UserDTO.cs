using System;
using System.Collections.Generic;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.SharedKernel.ViewModels.Users
{
    public class UserDTO
    {
        /// <example>1</example>
        public int Id { get; set; }

        /// <example>CarlosRoberto</example>
        public string Login { get; set; }
        public ICollection<FunctionDTO> Functions { get; set; }

        /// <example>05/08/2021 or null</example>
        public DateTime? LastAccess { get; set; }

        /// <example>20/07/1992</example>
        public DateTime CreatedAt { get; private set; }

        /// <example>20/07/1994 OR null</example>
        public DateTime? UpdatedAt { get; set; }

        /// <example>20/07/1998 or null</example>
        public DateTime? DeletedAt { get; private set; }
    }
}