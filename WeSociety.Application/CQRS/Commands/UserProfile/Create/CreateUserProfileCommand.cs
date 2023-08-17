using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Create
{
    public class CreateUserProfileCommand : ICommand<Response>
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public IFormFile Image { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
    }
}
