using System;
using Stock.Core.Dto;
using Stock.Core.Services.Common;

namespace Stock.Core.Services
{
    interface IUserService
    {
        UserDto Register(string name, string email, string password);
        LoginResult Login(string email, string password);
        UserDto Get(string token);
        OperationResult AddTicker(Guid userId, Guid companyId);
        OperationResult DeleteTicker(Guid userId, Guid companyId);
    }

    public class UserService : IUserService
    {
        public UserDto Register(string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        public LoginResult Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto Get(string token)
        {
            throw new NotImplementedException();
        }

        public OperationResult AddTicker(Guid userId, Guid companyId)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteTicker(Guid userId, Guid companyId)
        {
            throw new NotImplementedException();
        }
    }
}
