using System;

namespace StoreManager.SharedKernel.ViewModels
{
    public class FunctionDTO : ICloneable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Admin { get; set; }

        public object Clone()
        {
            var function = (FunctionDTO)MemberwiseClone();

            return function;
        }

        public FunctionDTO TypedClone()
        {
            return (FunctionDTO)Clone();
        }
    }
}