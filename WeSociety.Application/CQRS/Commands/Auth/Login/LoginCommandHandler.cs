﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Auth.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, DataResponse<GetLoginUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _uow;
        public LoginCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IJwtService jwtService, IUnitOfWork uow)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
            _uow = uow;
        }

        public async Task<DataResponse<GetLoginUserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var signInUser = await _userManager.FindByEmailAsync(request.Email);
            if (signInUser == null) throw new LoginException();

            var signinRes = await _userManager.CheckPasswordAsync(signInUser,request.Password);
            if(!signinRes) throw new LoginException();

            var userProfile = await _uow.UserProfiles.Get(x => x.UserId == signInUser.Id);

            var userIdentity = new ClaimsIdentity("Custom");

            string token = _jwtService.CreateToken(signInUser.Id, signInUser.Email, signInUser.UserName,userProfile.Id);
            var loggedUser = _mapper.Map<GetLoginUserDto>(signInUser);
            loggedUser.Token = token;
            loggedUser.FullName = userProfile.FullName;
            loggedUser.UserProfileId = userProfile.Id;
            loggedUser.Image = userProfile.Image;

            return new SuccessDataResponse<GetLoginUserDto>(loggedUser);
        }
    }
}
