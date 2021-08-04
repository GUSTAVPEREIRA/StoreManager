using System;
using System.Collections.Generic;
using StoreManager.Core.Domain;

namespace StoreManager.SharedKernel.ViewModels.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public ICollection<FunctionDTO> Functions { get; set; }
        public DateTime LastAccess { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }
    }
}