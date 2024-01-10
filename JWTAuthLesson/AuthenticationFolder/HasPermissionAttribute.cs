using Microsoft.AspNetCore.Authorization;

namespace JWTAuthLesson.AuthenticationFolder
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permission permission) 
            :base(policy: permission.ToString())
        { 
        }
    }
}
