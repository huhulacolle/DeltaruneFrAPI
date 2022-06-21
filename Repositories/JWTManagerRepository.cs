using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DeltaruneFrBackEnd.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    {
        { "user1","password1"},
        { "user2","password2"},
        { "user3","password3"},
    };
        public Tokens Authenticate(User users)
        {
            if (!UsersRecords.Any(x => x.Key == users.nom && x.Value == users.mdp))
            {
                return null;
            }
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Token"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.nom)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
