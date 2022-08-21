using DeltaruneFrBackEnd.Models;

namespace DeltaruneFrBackEnd.Repositories
{
    public class StaffRepository : IStaffRepository
    {

        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public StaffRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeleteStaff(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "DELETE FROM staffdr WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task EditStaff(StaffDR staff)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", staff.id);
            dictionary.Add("@nom", staff.nom);
            dictionary.Add("@photo", staff.photo);
            dictionary.Add("@description", staff.description);
            dictionary.Add("@card", staff.card);
            dictionary.Add("@lien", staff.lien);
            dictionary.Add("@nomLien", staff.nomLien);
            dictionary.Add("@idChapitre", staff.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"UPDATE staffdr 
                        SET nom = @nom, photo = @photo,description = @description, card = @card lien = @lien, nomLien = @nomLien, idChapitre = @idChapitre
                        WHERE id = @id";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<StaffDR>> GetAllStaffAsync()
        {
            string sql = "SELECT * FROM staffdr ORDER BY id DESC";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<StaffDR>(sql);
        }

        public async Task<IEnumerable<StaffDR>> GetStaff()
        {
            string sql = "SELECT DISTINCT nom, photo, description, card lien, nomLien FROM staffdr ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<StaffDR>(sql);
        }

        public async Task<IEnumerable<StaffDR>> GetStaffByChapter(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staffdr WHERE idChapitre = @id ORDER BY nom";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<StaffDR>(sql, parameters);
        }

        public async Task<IEnumerable<StaffDR>> GetStaffById(int id)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", id);
            parameters.AddDynamicParams(dictionary);

            string sql = "SELECT * FROM staffdr WHERE id = @id";

            using var connec = _connectionFactory.Create();
            return await connec.QueryAsync<StaffDR>(sql, parameters);
        }

        public async Task SetStaff(StaffDR staff)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@nom", staff.nom);
            dictionary.Add("@photo", staff.photo);
            dictionary.Add("@description", staff.description);
            dictionary.Add("@card", staff.card);
            dictionary.Add("@lien", staff.lien);
            dictionary.Add("@nomLien", staff.nomLien);
            dictionary.Add("@idChapitre", staff.idChapitre);
            parameters.AddDynamicParams(dictionary);

            string sql = @"INSERT INTO staffdr (nom, photo, description, card, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @card, @lien, @nomLien, @idChapitre)";

            using var connec = _connectionFactory.Create();
            await connec.ExecuteAsync(sql, parameters);
        }
    }
}
