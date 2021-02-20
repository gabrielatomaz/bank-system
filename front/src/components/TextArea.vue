<template>
    <div>
        <textarea
            :class="`textarea is-${color}`"
            @input="$emit('input', $event.target.value)"
            :value="value"
            :placeholder="placeholder"
        ></textarea>
    </div>
</template>

<script>
export default {
  name: "TextArea",

  props: {
    placeholder: String,
    value: String,
    color: String,
  },
};
</script>