using System.Collections.Generic;

namespace StoreManager.Core.Inventory.ViewModels
{
    public class NewProductDto
    {
        public string Name { get; set; }
        public List<NewVariantDto> VariantDtos { get; set; }
    }
}