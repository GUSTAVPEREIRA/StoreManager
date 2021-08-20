using System.Collections.Generic;

namespace Core.Inventory.ViewModels
{
    public class NewProductDto
    {
        public string Name { get; set; }
        public List<NewVariantDto> VariantDtos { get; set; }
    }
}