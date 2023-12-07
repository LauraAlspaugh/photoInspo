


namespace photoInspo.Services;
public class PhotosService
{
    private readonly PhotosRepository _photosRepository;

    public PhotosService(PhotosRepository photosRepository)
    {
        _photosRepository = photosRepository;
    }

    internal Photo CreatePhoto(Photo photoData)
    {
        Photo photo = _photosRepository.CreatePhoto(photoData);
        return photo;
    }

    internal string DestroyPhoto(int photoId, string userId)
    {
        Photo photo = GetPhotoById(photoId);
        if (photo.CreatorId != userId)
        {
            throw new Exception("not your photo to destroy!");
        }
        _photosRepository.DestroyPhoto(photoId);
        return "this had been destroyed!";
    }

    internal Photo GetPhotoById(int photoId)
    {
        Photo photo = _photosRepository.GetPhotoById(photoId);
        if (photo == null)
        {
            throw new Exception("not a valid id");

        }
        return photo;
    }

    internal List<Photo> GetPhotos()
    {
        List<Photo> photos = _photosRepository.GetPhotos();
        return photos;
    }
}