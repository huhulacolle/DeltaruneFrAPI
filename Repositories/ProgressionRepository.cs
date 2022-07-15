namespace DeltaruneFrBackEnd.Repositories
{
    public class ProgressionRepository : IProgressionRepository
    {

        private readonly DefaultSqlConnectionFactory defaultSqlConnectionFactory;

        public ProgressionRepository(DefaultSqlConnectionFactory defaultSqlConnectionFactory)
        {
            this.defaultSqlConnectionFactory = defaultSqlConnectionFactory;
        }

        public async Task<IEnumerable<Progression>> GetProgressionAsync()
        {
            string sql = "SELECT * FROM progression";

            using IDbConnection connec = defaultSqlConnectionFactory.Create();
            return await connec.QueryAsync<Progression>(sql);
        }
    }
}
