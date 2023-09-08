using MediatR;
using Microsoft.AspNetCore.Http;
using WeSociety.Application.CQRS.BaseModels;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommand : ICommand<Unit>
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public IFormFile Image { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
    }
}
