namespace photoInspo.Models;
public class AccountFavorite : Account
{
    public int FavoriteId { get; set; }
    public int PhotoId { get; set; }
}