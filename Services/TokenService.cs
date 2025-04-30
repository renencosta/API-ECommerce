using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace API_ECommerce.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            // Criar as Claims - Informações do usuário que quero guardar no Token
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            //Criar uma chave de segurança e criptografar ela
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"));

            //criptografando a chave de segurança
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            //montar um token
            var token = new JwtSecurityToken(
                
                issuer: "ecommerce",
                audience: "ecommerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
