using Microsoft.AspNetCore.Connections;

namespace DeltaruneFrBackEnd.Repositories
{
    public class VoixRepository : IVoixRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public VoixRepository(DefaultSqlConnectionFactory connectionFactory)        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeleteVoix(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "DELETE FROM beta WHERE voix = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task EditVoix(Staff beta)
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

            string sql = @"UPDATE voix 
                        SET nom = @nom, photo = @photo,description = @description, lien = @lien, nomLien = @nomLien, idChapitre = @idChapitre
                        WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<Staff>> GetAllVoixAsync()
        {
            string sql = "SELECT * FROM voix ORDER BY id DESC";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }

        public async Task<IEnumerable<Staff>> GetVoix()
        {
            string sql = "SELECT DISTINCT nom, photo, description, lien, nomLien FROM voix ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }

        public async Task<IEnumerable<Staff>> GetVoixByChapter(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM voix WHERE idChapitre = @id ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }

        public async Task<IEnumerable<Staff>> GetVoixById(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM voix WHERE id = @id";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql, parameters);
        }

        public async Task SetVoix(Staff beta)
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

            string sql = @"INSERT INTO voix (nom, photo, description, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @lien, @nomLien, @idChapitre)";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }
    }
}
