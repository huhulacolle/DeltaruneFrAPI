namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Staff>> GetStaff();
        public Task<IEnumerable<Chapitre>> GetChapitres();
    }
}
