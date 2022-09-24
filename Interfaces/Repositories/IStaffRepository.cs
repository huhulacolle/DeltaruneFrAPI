namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<StaffDR>> GetAllStaff();
        public Task<IEnumerable<StaffDR>> GetStaff();
        public Task<IEnumerable<StaffDR>> GetStaffById(int id);
        public Task<IEnumerable<StaffDR>> GetStaffByChapter(int id);
        public Task SetStaff(StaffDR beta);
        public Task EditStaff(StaffDR beta);
        public Task DeleteStaff(int id);
    }
}
