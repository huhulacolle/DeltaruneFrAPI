namespace DeltaruneFrBackEnd.Repositories
{
    public class TraducteurRepository : ITraducteurRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public TraducteurRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            string sql = "SELECT * FROM staff ORDER BY id DESC";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }
        public async Task<IEnumerable<Staff>> GetStaff()
        {
            string sql = "SELECT DISTINCT nom, photo, description, lien, nomLien FROM staff ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }
        public async Task<IEnumerable<Staff>> GetStaffById(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staff WHERE id = @id";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }
        public async Task<IEnumerable<Staff>> GetStaffByChapter(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staff WHERE idChapitre = @id ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }

        public async Task SetStaff(Staff staff)
        {
            string sql = @"INSERT INTO staff (nom, photo, description, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @lien, @nomLien, @idChapitre)";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, staff);
        }
        public async Task EditStaff(Staff staff)
        {
            string sql = @"UPDATE staff 
                        SET nom = @nom, photo = @photo,description = @description, lien = @lien, nomLien = @nomLien, idChapitre = @idChapitre
                        WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, staff);
        }
        public async Task DeleteStaff(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "DELETE FROM staff WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<Chapitre>> GetChapitres()
        {
            string sql = "SELECT numero AS chapitre FROM chapitre;";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Chapitre>(sql);
        }

        public async Task EditChapitre(int chap)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@chap", chap);
            parameters.AddDynamicParams(dictionary);

            string sql = "UPDATE chapitre SET numero = @chap WHERE id = 1";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }
    }
}
