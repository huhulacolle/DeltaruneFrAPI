namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Staff>> GetStaff();
        public Task SetStaff(Staff staff);
        public Task<IEnumerable<Chapitre>> GetChapitres();
    }
}
