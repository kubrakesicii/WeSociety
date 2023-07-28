﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Repositories;

namespace WeSociety.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserProfileRepository UserProfiles { get; }
        public IArticleRepository Articles { get; }
        public IFollowRelationshipRepository FollowRelationships { get; }
        Task<int> SaveChangesAsync();
    }
}
