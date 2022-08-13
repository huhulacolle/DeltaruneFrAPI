namespace DeltaruneFrBackEnd.Repositories
{
    public class TraducteurRepository : ITraducteurRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public TraducteurRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Traducteur>> GetAllStaff()
        {
            string sql = "SELECT * FROM staff ORDER BY id DESC";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Traducteur>(sql);
        }
        public async Task<IEnumerable<Traducteur>> GetStaff()
        {
            string sql = "SELECT DISTINCT nom, photo, description, lien, nomLien FROM staff ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Traducteur>(sql);
        }
        public async Task<IEnumerable<Traducteur>> GetStaffById(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staff WHERE id = @id";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Traducteur>(sql, parameters);
        }
        public async Task<IEnumerable<Traducteur>> GetStaffByChapter(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staff WHERE idChapitre = @id ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Traducteur>(sql, parameters);
        }

        public async Task SetStaff(Traducteur staff)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@nom", staff.nom);
            dictionary.Add("@photo", staff.photo);
            dictionary.Add("@description", staff.description);
            dictionary.Add("@lien", staff.lien);
            dictionary.Add("@nomLien", staff.nomLien);
            dictionary.Add("@idChapitre", staff.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"INSERT INTO staff (nom, photo, description, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @lien, @nomLien, @idChapitre)";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }
        public async Task EditStaff(Traducteur staff)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", staff.id);
            dictionary.Add("@nom", staff.nom);
            dictionary.Add("@photo", staff.photo);
            dictionary.Add("@description", staff.description);
            dictionary.Add("@lien", staff.lien);
            dictionary.Add("@nomLien", staff.nomLien);
            dictionary.Add("@idChapitre", staff.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"UPDATE staff 
                        SET nom = @nom, photo = @photo,description = @description, lien = @lien, nomLien = @nomLien, idChapitre = @idChapitre
                        WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
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
