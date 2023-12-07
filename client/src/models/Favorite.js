export class Favorite {
    constructor(data) {
        this.id = data.id || __id
        this.accountId = data.accountId
        this.photoId = data.photoId
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.photo = data.photo
        this.isFavorite = data.isFavorite
        this.favoriteId = data.favoriteId
    }
}