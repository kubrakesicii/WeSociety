using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;

namespace WeSociety.Application.CQRS.Commands.Auth.Login
{
    public class LoginCommand : ICommand<GetLoginUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
