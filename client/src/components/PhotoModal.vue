<template>
    <div class="modal fade" id="photoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <PhotoDetails />
                </div>
                <div class="modal-footer">

                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import PhotoDetails from './PhotoDetails.vue';
export default {
    setup() {
        return {
            photo: computed(() => AppState.activePhoto)
        };
    },
    components: { PhotoDetails }
};
</script>


<style lang="scss" scoped>
.modal-header {
    background-color: #E5E8E8;
}

.modal-footer {
    background-color: #E5E8E8;
}
</style>