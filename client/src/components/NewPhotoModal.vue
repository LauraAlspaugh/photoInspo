<template>
    <div class="modal fade" id="newPhotoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-center text-light" id="exampleModalLabel">Create a Recipe</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createPhoto()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" class="form-control" id="name"
                                aria-describedby="emailHelp" maxlength="255" required>

                        </div>
                        <div class="mb-3">
                            <label for="imgUrl" class="form-label">Image Url</label>
                            <input v-model="editable.img" type="url" class="form-control" id="imgUrl"
                                aria-describedby="emailHelp" maxlength="1000" required>

                        </div>
                        <!-- <div class="mb-3">
                            <label for="category" class="form-label">Category</label>
                            <select v-model="editable.category" type="text" class="form-select" id="category"
                                aria-describedby="emailHelp">
                                <option :value="category" v-for="category in categories" :key="category">
                                    {{ category }}
                                </option>
                            </select>
                        </div> -->
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <textarea v-model="editable.description" type="text" class="form-control" id="description"
                                rows="5" maxlength="255" required></textarea>
                        </div>

                        <button type="submit" class="btn btn-outline-dark">Submit</button>
                    </form>
                </div>
                <div class="modal-footer">
                    <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button> -->
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { photosService } from '../services/PhotosService.js';
import { Modal } from 'bootstrap';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            photos: computed(() => AppState.photos),
            async createPhoto() {
                try {
                    const photoData = editable.value
                    const photo = await photosService.createPhoto(photoData)
                    Pop.success('Photo created!')
                    Modal.getOrCreateInstance('#newPhotoModal').hide()
                    editable.value = {}
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>