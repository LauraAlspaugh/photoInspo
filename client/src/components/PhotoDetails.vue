<template>
    <div class="container-fluid">
        <section class="row">
            <div v-if="photo" class="col-12">
                <p class="fs-1 text-center mb-3 photo-name">{{ photo.name }}</p>
            </div>
        </section>
        <div class="section row">
            <div v-if="photo" class="col-12">
                <img :src="photo.img" :alt="photo.name">
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {
            photo: computed(() => AppState.activePhoto),
            photos: computed(() => AppState.photos)
        }
    }
};
</script>


<style lang="scss" scoped>
img {
    height: 400px;
    width: 100%;
    object-fit: cover;
    position: center;
}

.photo-name {
    font-family: 'Pinyon Script', cursive;
}
</style>