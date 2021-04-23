using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagement.Entities;
using ProjectManagement.Data.Interfaces;

namespace ProjectManagement.Api.Test
{
    public class ControllerFixture
    {
        public readonly List<User> Users = new List<User>
        {
            new User{ID =1, FirstName="Anusha", LastName="Sharma", Email="anusha.sharma@gmail.com" },
            new User{ID =2, FirstName="Amit", LastName="Gupta", Email="amit.gupta@gmail.com" },
            new User{ID =3, FirstName="Dharmendra", LastName="K", Email="dharmendra.k@gmail.com" }
        };

        private IQueryable<User> GetUsersList()
        {
            return Users.AsQueryable();
        }

        public Mock<IBaseRepository<User>> Setup()
        {
            var mockUserRepository = new Mock<IBaseRepository<User>>();
            mockUserRepository.Setup(x => x.Get()).Returns(GetUsersList());
            mockUserRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(GetUsersList().FirstOrDefault(x => x.ID == 1));
            mockUserRepository.Setup(x => x.Add(It.IsAny<User>())).Returns(GetUsersList().First());
            mockUserRepository.Setup(x => x.Update(It.IsAny<User>())).Returns(GetUsersList().First());
            return mockUserRepository;
        }
    }
}
