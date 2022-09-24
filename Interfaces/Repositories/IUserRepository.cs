namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IUserRepository
    {
        string Authenticate(User users);
        Task CreateAccount(User user);
        void GetAllAcount();
    }
}
