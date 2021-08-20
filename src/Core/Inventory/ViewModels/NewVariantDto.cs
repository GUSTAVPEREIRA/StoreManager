using System.Collections.Generic;

namespace Core.Inventory.ViewModels
{
    public class NewVariantDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        private List<ReferenceOptionDto> optionDtos;
    }
}