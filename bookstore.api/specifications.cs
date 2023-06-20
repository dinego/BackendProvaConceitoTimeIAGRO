public class Specifications
{
    public string OriginallyPublished { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public object Illustrator { get; set; } // Pode ser uma string ou uma lista de strings
    public object Genres { get; set; } // Pode ser uma string ou uma lista de strings
}