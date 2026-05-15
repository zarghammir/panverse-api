namespace PanVerse.Models;

public class Handpan
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Maker { get; set; } = string.Empty;
    public string Scale { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

