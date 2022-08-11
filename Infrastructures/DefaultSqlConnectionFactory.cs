namespace DeltaruneFrBackEnd.Infrastructures
{
    public class DefaultSqlConnectionFactory
    {
        public string ConnectionString { get; }
        public DefaultSqlConnectionFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public IDbConnection Create()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}
