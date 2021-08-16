using System;
using System.Collections.Generic;

namespace StoreManager.Core.Auth
{
    public class Function : ICloneable
    {
        public Function()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Admin { get; set; }
        public ICollection<User> Users { get; set; }

        public object Clone()
        {
            var function = (Function) MemberwiseClone();

            return function;
        }
    }
}