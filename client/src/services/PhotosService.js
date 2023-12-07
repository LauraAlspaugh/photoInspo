import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Photo } from "../models/Photo.js"
import { logger } from "../utils/Logger.js"
import { accountService } from "./AccountService.js"
import { api } from "./AxiosService.js"

class PhotosService {
    async getPhotos() {
        const res = await api.get('api/photos')
        logger.log(res.data)
        AppState.photos = res.data.map(pojo => new Photo(pojo))
        AppState.filteredPhotos = res.data.map(photo => new Photo(photo))
    }
    async favoritePhoto(photoId) {
        logger.log(`creating a favorite with ${photoId}`)
        const res = await api.post('api/favorites', { photoId });
        logger.log('this is what we are getting back from the favorite post', res.data)
        // AppState.favorites.push(new Favorite(res.data));
        AppState.myFavoritePhotos.push(new Favorite(res.data))
    }
    async unfavoritePhoto(favoriteId) {
        logger.log('trying to unfavorite this.')
        const res = await api.delete(`api/favorites/${favoriteId}`);
        AppState.myFavoritePhotos = AppState.myFavoritePhotos.filter(photo => photo.favoriteId != favoriteId);

        await accountService.getFavorites()
        return res.data


    }
    async destroyPhoto(photoId) {
        const res = await api.delete(`api/photos/${photoId}`)
        logger.log('destroying photo', res.data)
        AppState.photos = AppState.photos.filter((photo) => photo.id != photoId)
    }
    async createPhoto(photoData) {
        const res = await api.post('api/photos', photoData)
        logger.log('created a photo!', res.data)
        if (AppState.filter === 'Favorites') {
            AppState.photos.push(new Photo(res.data))
            return
        }
        if (AppState.filter === 'Home') {
            AppState.photos.push(new Photo(res.data))
            return
        }
        const newPhoto = new Photo(res.data)
        AppState.photos.push(newPhoto)
        // AppState.filteredRecipes.push(new Recipe(res.data))
        return newPhoto
    }
    filterPhotos(filter) {

        if (filter == "Home") {
            AppState.filteredPhotos = AppState.photos
        } logger.log('filter two ')

        if (filter == "Created") {
            AppState.filteredPhotos = AppState.photos.filter((photo) => photo.creatorId == AppState.account.id)
        } logger.log('filter three ')

        if (filter == "Favorites") {
            const filteredPhotos = []
            const photos = AppState.photos
            for (let i = 0; i < AppState.myFavoritePhotos.length; i++) {
                let favorite = photos.find(photo => photo.id == AppState.myFavoritePhotos[i].id)
                filteredPhotos.push(favorite)
            }
            AppState.filteredPhotos = filteredPhotos

        } logger.log('filter four')
        AppState.filter = filter

    }
    setActivePhoto(photoProp) {

        AppState.activePhoto = photoProp
    }
}
export const photosService = new PhotosService()