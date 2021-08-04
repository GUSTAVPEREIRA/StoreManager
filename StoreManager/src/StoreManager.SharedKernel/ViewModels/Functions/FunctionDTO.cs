using System;

namespace StoreManager.SharedKernel.ViewModels
{
    public class FunctionDTO : ICloneable
    {
        /// <example>10</example>
        public int Id { get; set; }

        /// <example>Administrador</example>
        public string Description { get; set; }

        /// <example>true</example>
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