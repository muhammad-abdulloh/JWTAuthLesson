using JWTAuthLesson.DataAccess;
using JWTAuthLesson.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthLesson.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _authDbContext;

        public UserService(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async ValueTask<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _authDbContext.Users.ToListAsync();
        }
    }
}
