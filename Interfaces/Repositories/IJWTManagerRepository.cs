namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
        Task CreateAccount(User user);

        void GetAllAcount();
    }
}
