using System.Collections.Generic;

namespace Core.Inventory
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Variant> Variants { get; set; }
    }
}