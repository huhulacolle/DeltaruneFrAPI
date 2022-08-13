namespace DeltaruneFrBackEnd.Repositories
{
    public class BetaRepository : IBetaRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public BetaRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Staff>> GetAllBetaAsync()
        {
            string sql = "SELECT * FROM beta ORDER BY id DESC";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }

        public async Task DeleteBeta(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "DELETE FROM beta WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task EditBeta(Staff beta)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", beta.id);
            dictionary.Add("@nom", beta.nom);
            dictionary.Add("@photo", beta.photo);
            dictionary.Add("@description", beta.description);
            dictionary.Add("@lien", beta.lien);
            dictionary.Add("@nomLien", beta.nomLien);
            dictionary.Add("@idChapitre", beta.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"UPDATE beta 
                        SET nom = @nom, photo = @photo,description = @description, lien = @lien, nomLien = @nomLien, idChapitre = @idChapitre
                        WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<Staff>> GetBeta()
        {
            string sql = "SELECT DISTINCT nom, photo, description, lien, nomLien FROM beta ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }

        public async Task<IEnumerable<Staff>> GetBetaByChapter(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM beta WHERE idChapitre = @id ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }

        public async Task<IEnumerable<Staff>> GetBetaById(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM beta WHERE id = @id";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }

        public async Task SetBeta(Staff beta)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@nom", beta.nom);
            dictionary.Add("@photo", beta.photo);
            dictionary.Add("@description", beta.description);
            dictionary.Add("@lien", beta.lien);
            dictionary.Add("@nomLien", beta.nomLien);
            dictionary.Add("@idChapitre", beta.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"INSERT INTO beta (nom, photo, description, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @lien, @nomLien, @idChapitre)";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }
    }
}
