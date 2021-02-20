<template>
  <div>
    <Banner :title="`Bem-vinde, ${user.name}!`" type="link">
      Agência: {{ user.account.agenncy }}
      <br />
      Número: {{ user.account.number }}
    </Banner>
    <div class="columns mt-5">
      <div class="column is-one-quarter">
        <div class="box ml-5">
          <Level :title="`R$ ${user.account.balance}`" heading="Saldo" />
        </div>
      </div>
      <div class="column mr-5">
        <div class="box">
          <div class="columns">
            <div class="column">
              <Button
                text="Sacar"
                color="link"
                :event="() => {}"
                size="medium"
              />
            </div>
            <div class="column">
              <Button
                text="Depositar"
                color="success"
                :event="() => {}"
                size="medium"
              />
            </div>
            <div class="column">
              <Button
                text="Pagar"
                color="danger"
                :event="() => {}"
                size="medium"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="columns m-5">
      <Table :header="header" :data="data" />
    </div>
  </div>
</template>

<script>
import { Banner, Level, Button, Table } from "../components";

export default {
  name: "Index",

  components: {
    Banner,
    Level,
    Button,
    Table,
  },

  data() {
    return {
      user: {
        name: "Gabriela",
        account: {
          agenncy: "0001",
          number: "9999999-9",
          balance: 500.0,
          transactions: [],
        },
      },
      data: [
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
        {
          transactionType: "Deposito",
          value: 400,
          description: "Bla bla bla",
          date: Date.now(),
        },
      ],
      header: [
        {
          field: "transactionType",
          title: "Tipo da Transição",
        },
        {
          field: "value",
          title: "Valor",
        },
        {
          field: "description",
          title: "Descrição",
        },
        {
          field: "date",
          title: "Data",
        },
      ],
    };
  },
};
</script>
<style scoped>
.box {
  min-height: 97px !important;
}
</style>