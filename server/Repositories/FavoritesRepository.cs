


namespace photoInspo.Repositories;
public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal PhotoFavorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
    INSERT INTO 
    favorites(photoId, accountId)
    VALUES(@PhotoId, @AccountId);

    SELECT
    fav.*,
    phot.*,
    acc.*
    FROM favorites fav
    JOIN photos phot ON fav.photoId = phot.id
    JOIN accounts acc ON acc.id = phot.creatorId
    WHERE fav.id = LAST_INSERT_ID();
    ";
        PhotoFavorite photoFavorites = _db.Query<Favorite, PhotoFavorite, Account, PhotoFavorite>(sql, (favorite, photoFavorite, account) =>
        {
            photoFavorite.FavoriteId = favorite.Id;
            photoFavorite.AccountId = favorite.AccountId;
            photoFavorite.Creator = account;

            return photoFavorite;

        }, favoriteData).FirstOrDefault();
        return photoFavorites;
    }

    internal void DestroyFavorite(int favoriteId)
    {
        string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";
        _db.Execute(sql, new { favoriteId });
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<PhotoFavorite> GetPhotoFavoritesByAccountId(string userId)
    {
        string sql = @"
    SELECT 
    fav.*,
    phot.*,
    acc.*
    FROM favorites fav
    JOIN photos phot ON fav.photoId = phot.id
    JOIN accounts acc ON acc.id = phot.creatorId
    WHERE fav.accountId = @userId;
    ";
        List<PhotoFavorite> photoFavorites = _db.Query<Favorite, PhotoFavorite, Account, PhotoFavorite>(sql, (favorite, photoFavorite, account) =>
        {
            photoFavorite.FavoriteId = favorite.Id;
            photoFavorite.AccountId = favorite.AccountId;
            photoFavorite.Creator = account;

            return photoFavorite;

        }, new { userId }).ToList();
        return photoFavorites;
    }
}