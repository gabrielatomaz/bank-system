<template>
  <div class="modal is-active">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
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
              :event="() => {}"
              :outlined="false"
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
import { Input, Button } from "./";
import TextArea from "./TextArea";

export default {
  name: "TransactionModal",

  components: {
    Input,
    Button,
    TextArea,
  },

  props: {
    title: String,
    close: Function,
    value: Number,
    transactionType: Object,
  },

  data() {
    return {
      description: "",
    };
  },

  computed: {
    color() {
      const color = {
        payment: "danger",
        deposit: "success",
        withdraw: "link",
      };

      return color[this.transactionType.name];
    },
  },
};
</script>
