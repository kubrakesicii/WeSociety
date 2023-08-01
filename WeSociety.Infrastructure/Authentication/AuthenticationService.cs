using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _uow;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork uow)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _uow = uow;

            var token = _httpContextAccessor.HttpContext.Items["token"];
        }

        //public async Task<string> GetId()
        //{
        //    return (await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User)).Id;
        //}
        //public bool IsAuthenticated => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        //public async Task<string> GetEmail()
        //{
        //    return (await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User)).Email;
        //}

        //public async Task<string> GetUserName()
        //{
        //    return (await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User)).Id;
        //}
        //public async Task<int> GetProfileId()
        //{       
        //    var httuse = _httpContextAccessor.HttpContext.User;
        //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        //    return (await _uow.UserProfiles.Get(x => x.UserId == userId)).Id;
        //}

        public bool IsAuthenticated => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public string Id => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("id"))?.Value;

        public string UserName => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("username"))?.Value;

        public string Username => throw new NotImplementedException();

        public string Email => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("email"))?.Value;

        public async Task<int> GetProfileId()
        {
            string userId = _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("id"))?.Value;
            return (await _uow.UserProfiles.Get(x => x.UserId == userId)).Id;
        }
    }
}
