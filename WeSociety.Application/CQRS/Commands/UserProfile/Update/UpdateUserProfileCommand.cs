﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Responses;

namespace WeSociety.Application.CQRS.Commands.UserProfile.Update
{
    public class UpdateUserProfileCommand : ICommand<DataResponse<GetUpdateUserDto>>
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
