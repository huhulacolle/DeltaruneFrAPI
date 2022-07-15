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

        public async Task EditProgression(Progression progression)
        {
            var dictionary = new Dictionary<string, object>();
            var parameters = new DynamicParameters(dictionary);

            dictionary.Add("@id", progression.id);
            dictionary.Add("@chapitre", progression.chapitre);
            dictionary.Add("@textures", progression.textures);
            dictionary.Add("@modif_code", progression.modif_code);
            dictionary.Add("@traduction", progression.traduction);
            dictionary.Add("@beta", progression.beta);
            dictionary.Add("@fini", progression.fini);
            parameters.AddDynamicParams(dictionary);

            string sql = @"UPDATE progression 
                        SET chapitre = @chapitre, textures = @textures, modif_code = @modif_code, traduction = @traduction, beta = @beta, fini = @fini
                        WHERE id = @id";

            using IDbConnection connec = defaultSqlConnectionFactory.Create();
            await connec.QueryAsync(sql, parameters);

        }
    }
}
