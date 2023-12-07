namespace photoInspo.Models;
public class PhotoFavorite : Photo
{
    public int FavoriteId { get; set; }
    public string AccountId { get; set; }
}