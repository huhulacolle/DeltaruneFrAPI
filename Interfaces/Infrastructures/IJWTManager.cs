namespace DeltaruneFrBackEnd.Interfaces.Infrastructures
{
    public interface IJWTManager
    {
        Tokens Authenticate(User users);
        Task CreateAccount(User user);
        void GetAllAcount();
    }
}
