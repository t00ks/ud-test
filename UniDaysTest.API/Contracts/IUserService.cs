using UniDaysTest.API.Models;

namespace UniDaysTest.API.Contracts
{
    public interface IUserService
    {
        bool SaveUser(User user);
        bool VerifyPassword(string attempt, string storedHash);
        string EncryptPassword(User user);
    }
}