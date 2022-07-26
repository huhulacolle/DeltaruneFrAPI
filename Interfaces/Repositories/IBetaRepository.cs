namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IBetaRepository
    {
        public Task<IEnumerable<Beta>> GetAllBetaAsync();
        public Task<IEnumerable<Beta>> GetBeta();
        public Task<IEnumerable<Beta>> GetBetaById(int id);
        public Task<IEnumerable<Beta>> GetBetaByChapter(int id);
        public Task SetBeta(Beta beta);
        public Task EditBeta(Beta beta);
        public Task DeleteBeta(int id);
    }
}
