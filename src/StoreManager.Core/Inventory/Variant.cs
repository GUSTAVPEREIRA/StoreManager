using System.Collections.Generic;

namespace StoreManager.Core.Inventory
{
    public class Variant
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}