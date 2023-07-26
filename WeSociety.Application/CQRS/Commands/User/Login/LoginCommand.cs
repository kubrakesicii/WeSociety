using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.User.Login
{
    public class LoginCommand : ICommand<DataResponse<GetLoginUserDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
