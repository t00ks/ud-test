using UniDaysTest.API.Models;

namespace UniDaysTest.API.Contracts
{
    public interface IUserRepository
    {
        User GetUser(string email);

        void InsertUser(User user, string encryptedPassword);

        void UpdateUser(User user);
    }
}