namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IProgressionRepository
    {
        public Task<IEnumerable<Progression>> GetProgressionAsync();
    }
}
