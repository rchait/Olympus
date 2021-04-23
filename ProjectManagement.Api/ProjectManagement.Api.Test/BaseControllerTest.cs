using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Api.Controllers;
using Xunit;
using System.Collections.Generic;
using ProjectManagement.Entities;


namespace ProjectManagement.Api.Test
{
    public class BaseControllerTest : IClassFixture<ControllerFixture>
    {
        private readonly ControllerFixture _controllerFixture;

        public BaseControllerTest(ControllerFixture controllerFixture)
        {
            _controllerFixture = controllerFixture;
        }

        private BaseController<User> _baseController;

        [Fact]
        public void GetAllUsers()
        {
            var baseRepository = _controllerFixture.Setup();
            _baseController = new BaseController<User>(baseRepository.Object);
            var result = _baseController.Get();
            var actual = result as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);
            var returnResult = actual.Value as IEnumerable<User>;
            Assert.Equal(3, returnResult.Count());
            Assert.Equal("Anusha", returnResult.ElementAt(0).FirstName);
        }

        [Fact]
        public void GetUsersById()
        {
            var baseRepository = _controllerFixture.Setup();
            _baseController = new BaseController<User>(baseRepository.Object);
            var result = _baseController.Get(1);
            var actual = result as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);
            var returnResult = actual.Value as User;
            Assert.Equal("Anusha", returnResult.FirstName);
        }

        [Fact]
        public void InsertUser()
        {
            var baseRepository = _controllerFixture.Setup();
            _baseController = new BaseController<User>(baseRepository.Object);
            User user4 = new User { ID = 4, FirstName = "Ram", LastName = "Singh", Email = "ram.singh@gmail.com" };
            var result = _baseController.Post(user4);
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateUser()
        {
            var baseRepository = _controllerFixture.Setup();
            _baseController = new BaseController<User>(baseRepository.Object);
            User user1 = new User { ID = 1, FirstName = "Ankitha", LastName = "Sharma", Email = "anusha.sharma@gmail.com" };
            var result = _baseController.Put(user1);
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteUserById()
        {
            var baseRepository = _controllerFixture.Setup();
            _baseController = new BaseController<User>(baseRepository.Object);
            baseRepository.Setup(x => x.Delete(1));
            _baseController.Delete(5);
            User userToDelete = _controllerFixture.Users.Find(x => x.ID == 5);
            _controllerFixture.Users.Remove(userToDelete);
            Assert.Equal(3, _controllerFixture.Users.Count);

        }
    }
}
