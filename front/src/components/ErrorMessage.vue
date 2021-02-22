<template>
    <div class="notification is-danger is-light">
        <button class="delete" @click="close"></button>
        <span> {{ message }} </span>
    </div>
</template>

<script>
export default {
    name: 'ErrorMessage',

    props: {
        message: {
            type: String,
            required: true,
        }
    },

    methods: {
        close() {
            this.$emit('close')
        }
    }
}
</script>