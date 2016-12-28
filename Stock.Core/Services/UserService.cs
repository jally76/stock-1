using System;
using System.Linq;
using AutoMapper;
using Stock.Core.AutoMapper;
using Stock.Core.DataAccess;
using Stock.Core.Domain;
using Stock.Core.Dto;
using Stock.Core.Services.Common;

namespace Stock.Core.Services
{
    public interface IUserService
    {
        UserDto Register(string name, string email, string password);
        LoginResult Login(string email, string password);
        UserDto Get(string email);
        void AddTicker(string email, Guid companyId);
        void DeleteTicker(string email, Guid companyId);
    }

    public class UserService : IUserService
    {
        private readonly IDataProvider _dataProvider;

        public UserService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        protected MappingEngine Mapper => AutoMapperConfiguration.Mapper;

        public UserDto Register(string name, string email, string password)
        {
            var query = _dataProvider.Where<User>(u => u.Email == email);
            if(query.Any())
                throw new Exception($"Exists user with email: {email}");

            var user = new User(email, name, password);
            user = _dataProvider.Create(user);
            var dto = Mapper.Map<UserDto>(user);
            return dto;
        }

        public LoginResult Login(string email, string password)
        {
            var result = new LoginResult();

            var user = _dataProvider.SingleOrDefault<User>(u => u.Email == email);
            if (user == null)
            {
                result.IsAuthenticated = false;
                result.Message = $"User with email {email} not exists";
                return result;
            }

            var isAuthenticated = user.IsValidPassword(password);
            if (isAuthenticated)
            {
                result.IsAuthenticated = true;
                result.User = Mapper.Map<UserDto>(user);
                return result;
            }
            else
            {
                result.IsAuthenticated = false;
                result.Message = "Incorrect password";
            }

            return result;
        }

        public UserDto Get(string email)
        {
            var user = _dataProvider.SingleOrDefault<User>(u => u.Email == email);

            return Mapper.Map<UserDto>(user);
        }

        public void AddTicker(string email, Guid companyId)
        {
            var user = _dataProvider.SingleOrDefault<User>(u => u.Email == email);
            var company = _dataProvider.SingleOrDefault<Company>(c => c.Id == companyId);

            if (user == null)
            {
                throw new Exception($"User with email {email} not exists");
            }

            user.AddTicker(company);

            _dataProvider.Update(user);
        }

        public void DeleteTicker(string email, Guid companyId)
        {
            var user = _dataProvider.SingleOrDefault<User>(u => u.Email == email);
            var company = _dataProvider.SingleOrDefault<Company>(c => c.Id == companyId);

            if (user == null)
            {
                throw new Exception($"User with email {email} not exists");
            }

            user.RemoveTicker(company);

            _dataProvider.Update(user);
        }
    }
}
