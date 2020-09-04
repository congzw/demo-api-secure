using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NbSites.Web.Demo.JWT.Helpers
{
    public class JwtSecurityTokenHelper
    {
        public string GenerateToken(GenerateTokenArgs args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(args.Secret);
            var claims = new List<Claim>();
            //username
            claims.Add(new Claim(ClaimTypes.Name, args.Id));

            if (args.ClaimInfos != null)
            {
                foreach (var claimInfo in args.ClaimInfos)
                {
                    claims.Add(new Claim(claimInfo.Key, claimInfo.Value));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = args.Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }

    public class GenerateTokenArgs
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public IDictionary<string, string> ClaimInfos { get; set; } = new Dictionary<string, string>();
        public DateTime? Expires { get; set; }
    }
}
