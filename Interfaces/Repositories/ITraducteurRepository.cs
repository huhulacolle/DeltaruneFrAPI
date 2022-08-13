namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface ITraducteurRepository
    {
        public Task<IEnumerable<Traducteur>> GetAllStaff();
        public Task<IEnumerable<Traducteur>> GetStaff();
        public Task<IEnumerable<Traducteur>> GetStaffById(int id);
        public Task<IEnumerable<Traducteur>> GetStaffByChapter(int id);
        public Task SetStaff(Traducteur staff);
        public Task EditStaff(Traducteur staff);
        public Task DeleteStaff(int id);
        public Task<IEnumerable<Chapitre>> GetChapitres();
        public Task EditChapitre(int chap);
    }
}
