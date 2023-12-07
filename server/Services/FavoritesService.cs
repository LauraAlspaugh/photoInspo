


namespace photoInspo.Services;
public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal PhotoFavorite CreateFavorite(Favorite favoriteData)
    {
        PhotoFavorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception("not a valid id to destroy!");
        }
        return favorite;
    }

    internal string DestroyFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);
        if (favorite.AccountId != userId)
        {
            throw new Exception("not yours to destroy!");
        }
        _favoritesRepository.DestroyFavorite(favoriteId);
        return "It really is gone bro!";
    }

    internal List<PhotoFavorite> GetPhotoFavoritesByAccountId(string userId)
    {
        List<PhotoFavorite> photoFavorites = _favoritesRepository.GetPhotoFavoritesByAccountId(userId);
        return photoFavorites;
    }
}