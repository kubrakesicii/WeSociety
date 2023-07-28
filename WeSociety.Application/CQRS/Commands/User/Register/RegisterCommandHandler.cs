﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.CQRS.BaseModels;
using WeSociety.Application.DTO.User;
using WeSociety.Application.Exceptions;
using WeSociety.Application.Responses;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Application.CQRS.Commands.User.Register
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

            var newUser = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            IdentityResult res = await _userManager.CreateAsync(newUser,request.Password);
            if(res.Succeeded) { }
            // User added successfully, user Id.

            //var userProfile = await _uow.UserProfiles.Get(x => x.UserId == newUser.Id);

            //_userManager.AddClaimsAsync(newUser, new List<Claim>
            //    {
            //        new Claim("id", newUser.Id),
            //        new Claim("email", newUser.Email),
            //        new Claim("username", newUser.UserName),
            //        new Claim("profileId", userProfile.Id.ToString())
            //    });

            return new SuccessDataResponse<GetUserDto>(_mapper.Map<GetUserDto>(newUser));

        }
    }
}
