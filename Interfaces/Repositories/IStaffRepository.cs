namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Chapitre>> GetChapitres();
    }
}
