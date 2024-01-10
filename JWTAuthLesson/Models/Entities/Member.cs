namespace JWTAuthLesson.Models.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
    }
}
