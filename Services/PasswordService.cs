using API_ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace API_ECommerce.Services
{
    public class PasswordService
    {
        // PasswordHasher - Classe pronta do .Net - PBKDF2 algoritmo usado por essa classe
        private readonly PasswordHasher<Cliente> _hasher = new();
        
        //Método para gerar um Hash
        public string HashPassword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }

        //Método para verificar o Hash
        public bool VerificarSenha(Cliente cliente, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);
            //retorna verdadeiro se as hash forem iguais e falso caso sejam diferentes
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
