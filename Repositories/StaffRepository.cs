namespace DeltaruneFrBackEnd.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DefaultSqlConnectionFactory _connectionFactory;

        public StaffRepository(DefaultSqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Chapitre>> GetChapitres()
        {
            string sql = "SELECT numero FROM chapitre";

            using IDbConnection connec = _connectionFactory.Create();
            return await connec.QueryAsync<Chapitre>(sql);
        }
    }
}
