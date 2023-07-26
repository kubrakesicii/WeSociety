using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommand : ICommand<Response>
    {
        public int Id { get; set; }

        public string UserName { get; set;}
        public string FullName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string Bio { get; set;}
    }
}
