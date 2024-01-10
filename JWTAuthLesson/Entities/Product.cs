namespace JWTAuthLesson.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public float Price { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
