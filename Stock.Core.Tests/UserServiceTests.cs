using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NSubstitute;
using NUnit.Framework;
using Stock.Core.Domain;
using Stock.Core.Services;
using Stock.Core.Services.Common;

namespace Stock.Core.Tests
{
    [TestFixture]
    public class UserServiceTests : AbstractServiceTests
    {
        private IUserService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new UserService(DataProvider);
        }

        [Test]
        public void RegisterTestUserExists()
        {
            DataProvider.Where(Arg.Any<Expression<Func<User, bool>>>()).Returns(new List<User> { new User() }.AsQueryable());

            var result = _sut.Register("userName", "qqq@gmail.com", "123");

            Assert.AreEqual(StatusOpearion.Error, result.StatusOpearion);

            DataProvider.DidNotReceive().Create(Arg.Any<User>());
        }

        [Test]
        public void RegisterTestUserNotExists()
        {
            DataProvider.Where(Arg.Any<Expression<Func<User, bool>>>()).Returns(new List<User>().AsQueryable());

            var result = _sut.Register("userName", "qqq@gmail.com", "123");

            DataProvider.Received().Create(Arg.Any<User>());
            Assert.AreEqual(StatusOpearion.Success, result.StatusOpearion);
        }
    }
}
