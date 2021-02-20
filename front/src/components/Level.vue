<template>
  <nav class="level">
    <div class="level-item has-text-centered">
      <div>
        <p class="heading">
          {{ heading }}
        </p>
        <p class="title">
          {{ title }}
        </p>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "Level",

  props: {
    heading: String,
    title: String
  },
};
</script>

<style>
</style>