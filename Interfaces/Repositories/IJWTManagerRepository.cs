namespace DeltaruneFrBackEnd.Interfaces.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
