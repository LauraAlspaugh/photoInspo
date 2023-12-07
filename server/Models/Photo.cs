namespace photoInspo.Models;
public class Photo
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}