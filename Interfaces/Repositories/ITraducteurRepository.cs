﻿namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface ITraducteurRepository
    {
        public Task<IEnumerable<Staff>> GetAllStaff();
        public Task<IEnumerable<Staff>> GetStaff();
        public Task<IEnumerable<Staff>> GetStaffById(int id);
        public Task<IEnumerable<Staff>> GetStaffByChapter(int id);
        public Task SetStaff(Staff staff);
        public Task EditStaff(Staff staff);
        public Task DeleteStaff(int id);
        public Task<IEnumerable<Chapitre>> GetChapitres();
        public Task EditChapitre(int chap);
    }
}
