using System.Collections.Generic;

namespace StoreManager.SharedKernel.ViewModels.Users
{
    public class NewUserDTO
    {
        public string Login { get; set; }
        public ICollection<FunctionDTO> Functions { get; set; }
    }
}