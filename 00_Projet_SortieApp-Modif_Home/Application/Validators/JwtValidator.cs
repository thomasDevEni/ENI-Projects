using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class JwtValidator
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtValidator(string secretKey, string issuer, string audience)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
        }

        public ClaimsPrincipal ValidateJwtToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // You can adjust this value according to your requirements
            };

            try
            {
                // Validate token and return claims if valid
                var claimsPrincipal = tokenHandler.ValidateToken(authToken, tokenValidationParameters, out var validatedToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenException ex)
            {
                // Token validation failed
                Console.WriteLine("Token validation failed: " + ex.Message);
                return null;
            }
        }
    }
}
