using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Core.Exceptions;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Auth.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, GetLoginUserDto>
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

        public async Task<GetLoginUserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var signInUser = await _userManager.FindByEmailAsync(request.Email);
            if (signInUser == null) throw new LoginException();

            var signinRes = await _userManager.CheckPasswordAsync(signInUser,request.Password);
            if(!signinRes) throw new LoginException();

            var userProfile = await _uow.UserProfiles.GetAsync(x => x.UserId == signInUser.Id,cancellationToken);

            var userIdentity = new ClaimsIdentity("Custom");

            string token = _jwtService.CreateToken(signInUser.Id, signInUser.Email, signInUser.UserName,userProfile.Id);
            var loggedUser = _mapper.Map<GetLoginUserDto>(signInUser);
            loggedUser.Token = token;
            loggedUser.FullName = userProfile.FullName;
            loggedUser.UserProfileId = userProfile.Id;
            loggedUser.Image = userProfile.Image;

            return loggedUser;
        }
    }
}
