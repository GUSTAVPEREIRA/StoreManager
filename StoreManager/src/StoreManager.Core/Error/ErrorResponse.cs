using System;

namespace StoreManager.Core.ViewModels
{
    public class ErrorResponse
    {
        public ErrorResponse(string idErro)
        {
            Id = idErro;
            Data = DateTime.Now;
            Mensagem = "Erro Inesperado.";
        }

        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
    }
}