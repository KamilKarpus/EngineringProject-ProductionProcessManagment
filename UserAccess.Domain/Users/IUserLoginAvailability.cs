namespace PPM.UserAccess.Domain.Users
{
    public interface IUserLoginAvailability
    {
        bool isAvailable(string login);
    }
}
