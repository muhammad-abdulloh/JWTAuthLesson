using JWTAuthLesson.Entities;

namespace JWTAuthLesson.Services.UserServices
{
    public interface IUserService
    {
        public ValueTask<IEnumerable<User>> GetAllUsersAsync();
    }
}
