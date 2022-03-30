using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebCursos.Domain.Services.Utils
{
    public class TokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string GerarToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var TokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var acessToken = tokenHandler.CreateToken(TokenDescriptior);
            return tokenHandler.WriteToken(acessToken);
        }
    }
}
