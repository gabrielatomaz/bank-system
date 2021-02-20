<template>
  <table class="table is-fullwidth">
    <thead>
      <tr>
        <th v-for="(column, index) in header" :key="index">
          {{ column.title }}
        </th>
      </tr>
    </thead>
    <tbody>
      <template v-for="(row, index) in data">
        <tr :key="index">
          <td v-for="(column, i) in header" :key="i">
            {{ row[column.field] }}
          </td>
        </tr>
      </template>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "Table",

  props: {
    header: Array,
    data: Array,
  },
};
</script>