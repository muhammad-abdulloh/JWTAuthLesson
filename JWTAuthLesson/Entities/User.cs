namespace JWTAuthLesson.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
