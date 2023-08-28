using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Auth.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, DataResponse<GetUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork uow)
        {
            _userManager = userManager;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<DataResponse<GetUserDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null) throw new UserExistsException();   //Email must be unique

            var userNameCheck = await _userManager.FindByNameAsync(request.UserName);
            if (userNameCheck != null) throw new UserExistsException();   //UserName must be unique

            var newUser = _mapper.Map<AppUser>(request);

            IdentityResult res = await _userManager.CreateAsync(newUser,request.Password);
            if(res.Succeeded) {
                // User added successfully, user Id.
                // Create empty profile for registered user
                var userProfile = new Domain.Aggregates.UserProfileRoot.UserProfile(newUser.Id);
                await _uow.UserProfiles.Insert(userProfile);
            }
      
            return new SuccessDataResponse<GetUserDto>(_mapper.Map<GetUserDto>(newUser));
        }
    }
}
