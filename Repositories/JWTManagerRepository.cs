namespace DeltaruneFrBackEnd.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {

        private readonly DefaultSqlConnectionFactory defaultSqlConnectionFactory;

        private IEnumerable<User> UsersRecords;

        public JWTManagerRepository(DefaultSqlConnectionFactory defaultSqlConnectionFactory)
        {
            this.defaultSqlConnectionFactory = defaultSqlConnectionFactory;
            GetAllAcount();
        }

        /*        private readonly Dictionary<string, string> UsersRecords = new Dictionary<string, string>
            {
                { "user1","password1"},
                { "user2","password2"},
                { "user3","password3"},
            };*/

        public async Task CreateAccount(User user)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@nom", user.nom);
            dictionary.Add("@mdp", BCrypt.Net.BCrypt.HashPassword(user.mdp));
            parameters.AddDynamicParams(dictionary);

            string sql = "INSERT INTO `user`(nom, mdp) VALUES (@nom, @mdp)";
            using IDbConnection connec = this.defaultSqlConnectionFactory.Create();
            await connec.QueryAsync(sql, parameters);
        }

        public Tokens Authenticate(User users)
        {
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
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        public void GetAllAcount()
        {
            string sql = "SELECT * FROM user";

            using IDbConnection connec = defaultSqlConnectionFactory.Create();
            UsersRecords = connec.Query<User>(sql);
        }

    }
}
