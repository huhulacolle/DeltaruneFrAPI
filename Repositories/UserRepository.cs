﻿namespace DeltaruneFrBackEnd.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DefaultSqlConnectionFactory defaultSqlConnectionFactory;

        private IEnumerable<User>? UsersRecords;

        public UserRepository(DefaultSqlConnectionFactory defaultSqlConnectionFactory)
        {
            this.defaultSqlConnectionFactory = defaultSqlConnectionFactory;
        }

        public async Task CreateAccount(User user)
        {
            GetAllAcount();

            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@nom", user.nom);
            dictionary.Add("@mdp", BCrypt.Net.BCrypt.HashPassword(user.mdp));
            parameters.AddDynamicParams(dictionary);

            if (UsersRecords.Any(x => x.nom.ToLower() == user.nom.ToLower() && BCrypt.Net.BCrypt.Verify(user.mdp, x.mdp)))
            {
                string sql = "INSERT INTO user (nom, mdp) VALUES (@nom, @mdp)";
                using IDbConnection connec = defaultSqlConnectionFactory.Create();
                await connec.QueryAsync(sql, parameters);
            }

        }

        public string Authenticate(User users)
        {
            GetAllAcount();

            if (!UsersRecords.Any(x => x.nom == users.nom && BCrypt.Net.BCrypt.Verify(users.mdp, x.mdp)))
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
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void GetAllAcount()
        {
            string sql = "SELECT * FROM user";

            using IDbConnection connec = defaultSqlConnectionFactory.Create();
            UsersRecords = connec.Query<User>(sql);
        }

    }
}
