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

            using var connec = defaultSqlConnectionFactory.Create();
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
                        SET chapitre = ifnull(@chapitre, chapitre), textures = ifnull(@textures, textures), 
                        modif_code = ifnull(@modif_code, modif_code), traduction = ifnull(@traduction, traduction), beta = ifnull(@beta, beta), 
                        fini = ifnull(@fini, fini)
                        WHERE id = @id";

            using var connec = defaultSqlConnectionFactory.Create();
            await connec.QueryAsync(sql, parameters);

        }
    }
}
