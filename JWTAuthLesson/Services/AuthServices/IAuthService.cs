namespace JWTAuthLesson.Services.AuthServices
{
    public interface IAuthService
    {
        public ValueTask<string> GenerateToken(string username, string role);
    }
}
