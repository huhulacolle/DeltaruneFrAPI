namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Staff>> GetAllStaff();
        public Task<IEnumerable<Staff>> GetStaff();
        public Task<IEnumerable<Staff>> GetStaffById(int id);
        public Task SetStaff(Staff staff);
        public Task EditStaff(Staff staff);
        public Task DeleteStaff(int id);
        public Task<IEnumerable<Chapitre>> GetChapitres();
    }
}
