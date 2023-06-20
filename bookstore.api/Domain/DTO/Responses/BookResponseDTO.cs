namespace Domain.DTO.Responses
{
    public class BookResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public SpecificationsDTO? Specifications { get; set; }
    }
}
