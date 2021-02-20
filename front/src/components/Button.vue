<template>
        <button 
            :class="['button', `is-${color}`, `is-${size}`, isOutlined, isFullWidth, isLoading]"
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
        outlined: {
            type: Boolean,
            default: true,
        }
    },
    computed: {
        isLoading() {
            return this.loading ? 'is-loading' : ''
        },
        isFullWidth() {
            return this.fullWidth ? 'is-fullwidth' : ''
        },
        isOutlined() {
            return this.outlined ? 'is-outlined' : ''
        }
    },
}
</script>
