<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <p class="home-title text-center p-5">Sharing Inspiration One Photo at a Time.</p>
      </div>
    </section>
    <section class="row">
      <div v-for="photo in photos" :key="photo.id" class="col-4 p-4 d-flex justify-content-center">
        <PhotoCard :photoProp="photo" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { photosService } from '../services/PhotosService.js';
import PhotoCard from '../components/PhotoCard.vue';

export default {
  setup() {
    onMounted(() => {
      getPhotos();
    });
    async function getPhotos() {
      try {
        await photosService.getPhotos();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      photos: computed(() => AppState.photos)
    };
  },
  components: { PhotoCard }
}
</script>

<style scoped lang="scss">
.home-title {
  color: #D3D3D3;
  font-family: 'Pinyon Script', cursive;
  font-size: 50px;
  text-shadow: 1px 1px 0px rgb(87, 82, 82);
}
</style>
