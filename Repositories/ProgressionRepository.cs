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
            string sql = @"UPDATE progression 
                        SET chapitre = ifnull(@chapitre, chapitre), textures = ifnull(@textures, textures), 
                        modif_code = ifnull(@modif_code, modif_code), traduction = ifnull(@traduction, traduction), beta = ifnull(@beta, beta), 
                        fini = ifnull(@fini, fini)
                        WHERE id = @id";

            using var connec = defaultSqlConnectionFactory.Create();
            await connec.ExecuteAsync(sql, progression);

        }
    }
}
