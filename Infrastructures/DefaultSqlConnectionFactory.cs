namespace DeltaruneFrBackEnd.Infrastructures
{
    public class DefaultSqlConnectionFactory
    {
        public string connectionString { get; }
        public DefaultSqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection Create()
        {
            return new MySqlConnection(this.connectionString);
        }
    }
}
