namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IJWTManagerRepository
    {
        string Authenticate(User users);
        Task CreateAccount(User user);
        void GetAllAcount();
    }
}
