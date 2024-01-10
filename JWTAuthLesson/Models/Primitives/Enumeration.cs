namespace JWTAuthLesson.Models.Primitives
{
    public class Enumeration<T> where T : class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
