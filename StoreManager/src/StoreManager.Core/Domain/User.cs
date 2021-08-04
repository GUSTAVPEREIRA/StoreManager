using System;
using System.Collections.Generic;

namespace StoreManager.Core.Domain
{
    public class User
    {
        public User()
        {
            Functions = new List<Function>();
            CreatedAt = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Function> Functions { get; set; }
        public DateTime LastAccess { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        public void DeleteUser()
        {
            DeletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}