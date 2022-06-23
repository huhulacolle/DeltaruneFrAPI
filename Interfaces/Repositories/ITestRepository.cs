namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface ITestRepository
    {
        Task<IEnumerable<Chapitre>> TestSQL();
    }
}
