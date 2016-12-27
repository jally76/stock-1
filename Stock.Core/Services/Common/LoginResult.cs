using Stock.Core.Dto;

namespace Stock.Core.Services.Common
{

    public class LoginResult : OperationResult
    {
        public bool IsAuthenticated { get; set; }
        public UserDto User { get; set; }
    }
}
