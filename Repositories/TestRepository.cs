namespace DeltaruneFrBackEnd.Repositories
{
    public class TestRepository : ITestRepository
    {

        private readonly DefaultSqlConnectionFactory defaultSqlConnectionFactory;

        public TestRepository(DefaultSqlConnectionFactory defaultSqlConnectionFactory)
        {
            this.defaultSqlConnectionFactory = defaultSqlConnectionFactory;
        }

        public async Task<IEnumerable<Chapitre>> TestSQL()
        {
            string sql = "SELECT * FROM chapitre";

            using IDbConnection connec = this.defaultSqlConnectionFactory.Create();
            return await connec.QueryAsync<Chapitre>(sql);
        }
    }
}
