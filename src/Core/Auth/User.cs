using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Auth
{
    public class User : ICloneable
    {
        public User()
        {
            Functions = new List<Function>();
            CreatedAt = DateTime.UtcNow;
            LastAccess = null;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Function> Functions { get; set; }
        public DateTime? LastAccess { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        public object Clone()
        {
            var user = (User) MemberwiseClone();
            var functions = new List<Function>();
            user.Functions.ToList().ForEach(x => functions.Add((Function) x.Clone()));
            user.Functions = functions;

            return user;
        }

        public User TypedClone()
        {
            return (User) Clone();
        }

        public void DeleteUser()
        {
            DeletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UnDeleteUser()
        {
            DeletedAt = null;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}