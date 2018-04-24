using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniDaysTest.API.Contracts;
using UniDaysTest.API.Services;
using Moq;
using UniDaysTest.API.Models;
using System;

namespace UniDaysTest.Tests
{
    [TestClass]
    public class UserServiceTests
    {

        public  Mock<IUserRepository> GetMockRepo()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(m => m.GetUser(It.Is<string>(e => e == "timcrittenden@gmail.com"))).Returns(new User(
                userId: 1,
                email: "timcrittenden@gmail.com",
                password: "$2a$15$ARmSriRbdz/UnjN0FxKlKOvwbGTZ75gK42iNdKLW8KCYX9XF4h9AK",
                createdDate: DateTime.Now,
                lastUpdateDate: DateTime.Now
            ));

            return mockRepo;
        }

        [TestMethod]
        public void SaveUser_New()
        {
            var mockRepo = GetMockRepo();
            var service = new UserService(mockRepo.Object);

            var success = service.SaveUser(new User(
                email: "mr-t@gmail.com",
                password: "icanhazcheeseburgers"
            ));

            Assert.IsTrue(success);

            mockRepo.Verify(m => m.InsertUser(It.IsAny<User>(), It.IsAny<string>()), Times.Exactly(1));
            mockRepo.Verify(m => m.GetUser(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void SaveUser_Duplicate()
        {
            var mockRepo = GetMockRepo();
            var service = new UserService(mockRepo.Object);

            var success = service.SaveUser(new User(
                email: "timcrittenden@gmail.com",
                password: "icanhazcheeseburgers"
            ));

            Assert.IsFalse(success);

            mockRepo.Verify(m => m.InsertUser(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
            mockRepo.Verify(m => m.GetUser(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void EncryptPassword_IsVerifyable()
        {
            var service = new UserService(null);

            var user = new User(
                email: "timcrittenden@gmail.com",
                password: "icanhazcheeseburgers"
            );

            var password_pass = service.EncryptPassword(user);
            var isVerified = service.VerifyPassword("icanhazcheeseburgers", password_pass);

            Assert.IsTrue(isVerified);
        }
    }
}
