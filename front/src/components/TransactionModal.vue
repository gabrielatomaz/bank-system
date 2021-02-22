<template>
  <div class="modal is-active">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <ErrorMessage 
          :message="errorMessage"
          v-if="showErrorMessage" 
          @close="closeErrorMessage"
        />
        <span :class="`title is-4 has-text-${color}`"> Transação </span>
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
          <div class="filed-body mt-1">
            <TextArea
              v-model="description"
              :color="color"
              placeholder="Insira uma descrição!"
            />
          </div>
          <div class="filed-body">
            <Button
              :text="transactionType.text"
              :color="color"
              :event="emitTransaction"
              :outlined="false"
              :disabled="!enableButton()"
              :loading="loading"
              class="mt-1"
            />
          </div>
        </div>
      </div>
    </div>
    <button class="modal-close is-large" @click="close"></button>
  </div>
</template>

<script>
import { Input, Button, ErrorMessage } from "./";
import TextArea from "./TextArea";

export default {
  name: "TransactionModal",

  components: {
    Input,
    Button,
    TextArea,
    ErrorMessage,
  },

  props: {
    close: Function,
    transactionType: Object,
    errorMessage: String,
    loading: Boolean,
  },

  data() {
    return {
      description: '',
      value: null,
      showErrorMessage: false,
    };
  },

  watch: {
    errorMessage() {
      this.showErrorMessage = true;
    }
  },

  computed: {
    transactionTypeName() {
      const { name } = this.transactionType;

      return name;
    },

    color() {
      const color = {
        payment: "danger",
        deposit: "success",
        withdraw: "link",
      };

      return color[this.transactionTypeName];
    },
  },

  methods: {
    enableButton() {
      return this.value > 0;
    },

    emitTransaction() {
      const transaction = { 
        description: this.description,
        value: this.value,
        type: this.transactionTypeName,
      };

      this.$emit('transaction', transaction);
    },

    closeErrorMessage() {
      this.showErrorMessage = false;
    },
  },
};
</script>
