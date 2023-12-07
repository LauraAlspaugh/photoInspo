<template>
    <div class="photo-card mb-3 text-center">
        <img :src="photoProp.img" alt="photo image">
        <span v-if="isFavPhoto" @click.stop="unfavoritePhoto(isFavPhoto.favoriteId)" role="button"><i
                class="fs-2 mdi mdi-heart text-center" title="unfavorite this photo"></i></span>
        <span v-else @click.stop="favoritePhoto(photoProp.id)" role="button"><i
                class="fs-2 mdi mdi-heart-outline text-center" title="favorite this photo"></i></span>
        <i class="mdi mdi-close fs-2" title="delete this photo" type="button" @click="destroyPhoto()"></i>
        <p class="fs-4 photo-name">{{ photoProp.name }}</p>
        <p>{{ photoProp.description }}</p>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Photo } from '../models/Photo.js';
import { photosService } from '../services/PhotosService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
export default {
    props: { photoProp: { type: Photo, required: true } },
    setup(props) {
        return {
            photos: computed(() => AppState.photos),
            isFavPhoto: computed(() => AppState.myFavoritePhotos.find((photo) => photo.id == props.photoProp.id || photo.photoId == props.photoProp.id)),
            async favoritePhoto() {
                try {
                    const photoId = props.photoProp.id;
                    logger.log('favorite photo with photo id', photoId)
                    await photosService.favoritePhoto(photoId);
                }
                catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },
            async unfavoritePhoto(favoriteId) {
                try {

                    const recipeId = props.photoProp.id;
                    logger.log('we are trying to unfavorite this photo', recipeId)
                    await photosService.unfavoritePhoto(favoriteId);
                }
                catch (error) { Pop.error(error) }
            },
            async destroyPhoto() {
                try {
                    const wantstoDestroy = await Pop.confirm('Are you sure you want to destroy this Photot? ')
                    if (!wantstoDestroy) {
                        return
                    } await photosService.destroyPhoto(props.photoProp.id)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.photo-card {
    width: 22rem;
    border: 2px solid #7F8C8D;
    padding: 5px;
    border-radius: 7px;
    /* From https://css.glass */
    background: rgba(187, 174, 174, 0.62);
    border-radius: 16px;
    box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
    backdrop-filter: blur(3.6px);
    -webkit-backdrop-filter: blur(3.6px);
    border: 1px solid #7F8C8D(30, 23, 23, 0.78);
}

img {
    border-radius: 7px;
    width: 21rem;
    height: 18rem;
    object-fit: cover;
    position: center;
    ;
}

.photo-name {
    font-family: 'Pinyon Script', cursive;
    text-shadow: 2px 1px 2px rgb(87, 82, 82);
}
</style>