namespace DeltaruneFrBackEnd.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public StaffRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Staff>> GetStaff()
        {
            string sql = "SELECT * FROM staff";

            using IDbConnection connec = _connectionFactory.Create();
            return await connec.QueryAsync<Staff>(sql);
        }
        public async Task SetStaff(Staff staff)
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

            string sql = @"INSERT INTO staff (nom, photo, description, card, lien, nomLien, idChapitre) 
                            VALUES (@nom, @photo, @description, @card, @lien, @nomLien, @idChapitre)";

            using IDbConnection connec = _connectionFactory.Create();
            await connec.QueryAsync(sql, parameters);
        }

        public async Task<IEnumerable<Chapitre>> GetChapitres()
        {
            string sql = "SELECT numero FROM chapitre";

            using IDbConnection connec = _connectionFactory.Create();
            return await connec.QueryAsync<Chapitre>(sql);
        }
    }
}
