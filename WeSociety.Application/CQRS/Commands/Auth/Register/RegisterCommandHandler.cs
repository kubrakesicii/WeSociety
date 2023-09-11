using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Interfaces;
using WeSociety.Core.Exceptions;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.Auth.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, GetUserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> _elasticSearchService;
        public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper,
            IUnitOfWork uow, IElasticSearchService<Domain.Aggregates.UserProfileRoot.UserProfile> elasticSearchService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _uow = uow;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<GetUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
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
                await _uow.UserProfiles.InsertAsync(userProfile, cancellationToken);

                //ELK INDEXING
                var createRes = await _elasticSearchService.CreateIndexAsync("users", newUser.Id, new Domain.Aggregates.UserProfileRoot.UserProfile(0,"",newUser.Id));
            }

            return _mapper.Map<GetUserDto>(newUser);
        }
    }
}
