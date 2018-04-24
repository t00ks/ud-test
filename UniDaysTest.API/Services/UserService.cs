using System;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using UniDaysTest.API.Contracts;
using UniDaysTest.API.Data;
using UniDaysTest.API.Models;

namespace UniDaysTest.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool SaveUser(User user)
        {
            //see if user exists
            var savedUser = _repo.GetUser(user.Email);
            if (savedUser == null)
            {
                string password = EncryptPassword(user);
                _repo.InsertUser(user, password);
                
                return true;
            }

            return false;
        }

        public string EncryptPassword(User user) => BCrypt.Net.BCrypt.HashPassword(user.Password, 10);

        public bool VerifyPassword(string attempt, string storedHash) =>  BCrypt.Net.BCrypt.Verify(attempt, storedHash);
    }
}