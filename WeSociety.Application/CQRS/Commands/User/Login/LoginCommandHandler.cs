using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.User.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, DataResponse<GetLoginUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<DataResponse<GetLoginUserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var signInUser = await _userManager.FindByEmailAsync(request.Email);
            if (signInUser == null) throw new LoginException();

            var signinRes = await _userManager.CheckPasswordAsync(signInUser,request.Password);
            if(!signinRes) throw new LoginException();

            string token = _jwtService.CreateToken(signInUser.Id, signInUser.Email, signInUser.UserName);
            var loggedUser = _mapper.Map<GetLoginUserDto>(signInUser);
            loggedUser.Token = token;

            return new SuccessDataResponse<GetLoginUserDto>(loggedUser);
        }
    }
}
