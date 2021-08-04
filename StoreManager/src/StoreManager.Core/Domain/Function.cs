using System.Collections.Generic;

namespace StoreManager.Core.Domain
{
    public class Function
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Admin { get; set; }
        public ICollection<User> Users { get; set; }
    }
}