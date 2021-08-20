using System;

namespace Core.Auth.ViewModels
{
    public class FunctionDto : ICloneable
    {
        /// <example>10</example>
        public int Id { get; set; }

        /// <example>Administrador</example>
        public string Description { get; set; }

        /// <example>true</example>
        public bool Admin { get; set; }

        public object Clone()
        {
            var function = (FunctionDto) MemberwiseClone();

            return function;
        }

        public FunctionDto TypedClone()
        {
            return (FunctionDto) Clone();
        }
    }
}