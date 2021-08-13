using System.Collections.Generic;

namespace StoreManager.Core.Inventory
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Variant> Variants { get; set; }
    }
}