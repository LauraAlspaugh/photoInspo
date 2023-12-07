



namespace photoInspo.Repositories;
public class PhotosRepository
{
    private readonly IDbConnection _db;

    public PhotosRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Photo CreatePhoto(Photo photoData)
    {
        string sql = @"
    INSERT INTO
    photos(name, img, description,  creatorId)
    VALUES(@Name, @Img, @Description, @CreatorId);
    SELECT
    phot.*,
    acc.*
    FROM photos phot
    JOIN accounts acc ON phot.creatorId = acc.id
    WHERE phot.id = LAST_INSERT_ID();
    ";
        Photo photo = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
        {
            photo.Creator = account;
            return photo;
        }, photoData).FirstOrDefault();
        return photo;

    }

    internal void DestroyPhoto(int photoId)
    {
        string sql = @"
DELETE FROM photos WHERE id = @photoId LIMIT 1;
SELECT phot.*,
    acc.*
    FROM photos phot
    JOIN accounts acc ON phot.creatorId = acc.id
    Where phot.id = @photoId;
";
        _db.Execute(sql, new { photoId });
    }

    internal Photo GetPhotoById(int photoId)
    {
        string sql = @"
    SELECT phot.*,
    acc.*
    FROM photos phot
    JOIN accounts acc ON phot.creatorId = acc.id
    Where phot.id = @photoId;
    ";
        Photo photo = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
        {
            photo.Creator = account;
            return photo;
        }, new { photoId }).FirstOrDefault();
        return photo;
    }

    internal List<Photo> GetPhotos()
    {
        string sql = @"
    SELECT
    phot.*,
    acc.*
    FROM photos phot
    JOIN accounts acc ON phot.creatorId = acc.id
    ;";
        List<Photo> photos = _db.Query<Photo, Account, Photo>(sql, (photo, account) =>
        {
            photo.Creator = account;
            return photo;
        }).ToList();
        return photos;

    }
}
