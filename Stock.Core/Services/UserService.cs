using System;
using System.Linq;
using AutoMapper;
using Ninject;
using Stock.Core.AutoMapper;
using Stock.Core.DataAccess;
using Stock.Core.Domain;
using Stock.Core.Dto;
using Stock.Core.Services.Common;

namespace Stock.Core.Services
{
    interface IUserService
    {
        UserDto Register(string name, string email, string password);
        LoginResult Login(string email, string password);
        UserDto Get(string token);
        void AddTicker(string email, Guid companyId);
        void DeleteTicker(string email, Guid companyId);
    }

    public class UserService : IUserService
    {
        [Inject]
        public IDataProvider DataProvider { get; set; }

        protected MappingEngine Mapper => AutoMapperConfiguration.Mapper;

        public UserDto Register(string name, string email, string password)
        {
            if(DataProvider.Where<User>(u => u.Email == email).Any())
                throw new Exception($"Exists user with email: {email}");

            var user = new User(email, name, password);
            user = DataProvider.Create(user);
            var dto = Mapper.Map<UserDto>(user);
            return dto;
        }

        public LoginResult Login(string email, string password)
        {
            var result = new LoginResult();

            var user = DataProvider.SingleOrDefault<User>(u => u.Email == email);
            if (user == null)
            {
                throw new Exception($"User with email {email} not exists");
            }

            var isAuthenticated = user.IsValidPassword(password);
            if (isAuthenticated)
            {
                result.IsAuthenticated = true;
                result.User = Mapper.Map<UserDto>(user);
            }
            else
            {
                throw new Exception($"Incorrect password");
            }

            return result;
        }

        public UserDto Get(string token)
        {
            throw new NotImplementedException();
        }

        public void AddTicker(string email, Guid companyId)
        {
            var user = DataProvider.SingleOrDefault<User>(u => u.Email == email);
            var company = DataProvider.SingleOrDefault<Company>(c => c.Id == companyId);

            if (user == null)
            {
                throw new Exception($"User with email {email} not exists");
            }

            user.AddTicker(company);

            DataProvider.Update(user);
        }

        public void DeleteTicker(string email, Guid companyId)
        {
            var user = DataProvider.SingleOrDefault<User>(u => u.Email == email);
            var company = DataProvider.SingleOrDefault<Company>(c => c.Id == companyId);

            if (user == null)
            {
                throw new Exception($"User with email {email} not exists");
            }

            user.RemoveTicker(company);

            DataProvider.Update(user);
        }
    }
}
