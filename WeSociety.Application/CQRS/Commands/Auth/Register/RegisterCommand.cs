using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;

namespace WeSociety.Application.CQRS.Commands.Auth.Register
{
    public class RegisterCommand : ICommand<GetUserDto>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
