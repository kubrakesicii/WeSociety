using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using WeSociety.Application.Exceptions;

namespace WeSociety.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class Authorize : Attribute, IAuthorizationFilter
    {

        public Authorize() : base()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var authUserRoleId = context.HttpContext.Items["RoleId"];
            if (authUserRoleId == null)
            {
                // user authorize edilmemiş. UnAuth dön
                //context.Result = new JsonResult(new { data = "", message = "UNAUTHORIZED", statusCode = StatusCodes.Status401Unauthorized }) { StatusCode = StatusCodes.Status401Unauthorized };
               // throw new AuthenticationException();
            }
            else
            {
                
            }
        }
    }
}
