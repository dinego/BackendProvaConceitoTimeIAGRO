namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Specifications? Specifications { get; set; }
    }
}