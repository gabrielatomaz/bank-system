<template>
  <div>
    <Banner :title="`Bem-vinde, ${user.name}!`" type="link">
      Agência: {{ user.account.agency }}
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
                :event="
                  () => {
                    showTransactionModal({ name: 'withdraw', text: 'Sacar' });
                  }
                "
                size="medium"
              />
            </div>
            <div class="column">
              <Button
                text="Depositar"
                color="success"
                :event="
                  () => {
                    showTransactionModal({
                      name: 'deposit',
                      text: 'Depositar',
                    });
                  }
                "
                size="medium"
              />
            </div>
            <div class="column">
              <Button
                text="Pagar"
                color="danger"
                :event="
                  () => {
                    showTransactionModal({ name: 'payment', text: 'Pagar' });
                  }
                "
                size="medium"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="columns m-5">
      <Table :header="tableHeader" :data="user.account.transactions" />
    </div>
    <TransactionModal
      title="Sacar"
      v-if="isTransactionModalOpen"
      :close="closeransactionModal"
      :transactionType="transactionType"
    />
  </div>
</template>

<script>
import { Banner, Level, Button, Table, TransactionModal } from "../components";
import { userService, accountService, transactionService } from '../services';

export default {
  name: "Index",

  components: {
    Banner,
    Level,
    Button,
    Table,
    TransactionModal,
  },

  async mounted() {
    const user = await userService.getBy(1);
    let account = await accountService.getByUserId(user.id);
    const transactions = await transactionService.getByAccountId(account.id);

    account = { ...account, transactions: { ...transactions } };
    this.user = { ...user, account };
  },

  data() {
    return {
      transactionType: {},
      isTransactionModalOpen: false,
      user: {},
      tableHeader: [
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

  methods: {
    showTransactionModal({ name, text }) {
      this.transactionType = {
        name,
        text,
      };

      this.isTransactionModalOpen = true;
    },

    closeransactionModal() {
      this.isTransactionModalOpen = false;
    },
  },
};
</script>
<style scoped>
.box {
  min-height: 97px !important;
}
</style>