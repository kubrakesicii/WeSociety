using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommand : ICommand<GetUpdateUserDto>
    {
        [FromRoute]
        public int id { get; set; }

        public string FullName { get; set; }
        public IFormFile? Image { get; set; }
        public string Bio { get; set;}
        public string Github { get; set; }
        public string Linkedin { get; set; }
    }
}
