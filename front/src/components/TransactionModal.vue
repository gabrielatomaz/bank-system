<template>
  <div class="modal is-active">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <span :class="`title is-4 has-text-${color}`">
          Transação
        </span>
        <div class="field mt-5">
          <div class="field-body">
            <Input
              type="number"
              placeholder="Valor"
              icon="money-bill-wave"
              :color="color"
              v-model="value"
            />
          </div>
        </div>
      </div>
    </div>
    <button class="modal-close is-large" @click="close"></button>
  </div>
</template>

<script>
import { Input } from "./";

export default {
  name: "TransactionModal",

  components: {
    Input,
  },

  props: {
    title: String,
    close: Function,
    value: Number,
    transactionType: Object,
  },

  computed: {
      color() {
          const color = {
              payment: 'danger',
              deposit: 'success',
              withdraw: 'link',
          }

          return color[this.transactionType.name]
      },
      
      isWithdrawTransaction() {
          const { name } = this.transactionType

          return name === 'withdraw'
      }
  }
};
</script>
