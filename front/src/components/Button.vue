<template>
        <button 
            :class="['button', `is-${color}`, `is-${size}`, 'is-outlined', isFullWidth, isLoading]"
            @click="event"
            v-html="text"
        />
</template>

<script>
export default {
    name: 'Button',
    
    props: {
        text: { 
            type: String,
        },
        event: {
            type: Function,
            required: true,
        },
        loading: {
            type: Boolean,
            default: false,
        },
        fullWidth: {
            type: Boolean,
            default: true,
        },
        color: {
            type: String,
        },
        size: {
            type: String,
        },
    },
    computed: {
        isLoading() {
            return this.loading ? 'is-loading' : ''
        },
        isFullWidth() {
            return this.fullWidth ? 'is-fullwidth' : ''
        }
    },
}
</script>
