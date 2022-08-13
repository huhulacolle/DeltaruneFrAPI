namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IBetaRepository
    {
        public Task<IEnumerable<Staff>> GetAllBetaAsync();
        public Task<IEnumerable<Staff>> GetBeta();
        public Task<IEnumerable<Staff>> GetBetaById(int id);
        public Task<IEnumerable<Staff>> GetBetaByChapter(int id);
        public Task SetBeta(Staff beta);
        public Task EditBeta(Staff beta);
        public Task DeleteBeta(int id);
    }
}
