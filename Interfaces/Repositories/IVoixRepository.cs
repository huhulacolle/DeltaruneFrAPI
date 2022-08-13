namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IVoixRepository
    {
        public Task<IEnumerable<Staff>> GetAllVoixAsync();
        public Task<IEnumerable<Staff>> GetVoix();
        public Task<IEnumerable<Staff>> GetVoixById(int id);
        public Task<IEnumerable<Staff>> GetVoixByChapter(int id);
        public Task SetVoix(Staff beta);
        public Task EditVoix(Staff beta);
        public Task DeleteVoix(int id);
    }
}
