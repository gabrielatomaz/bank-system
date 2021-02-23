<template>
  <div>
    <Banner :title="`Bem-vinde, ${userName}!`" type="link">
      Agência: {{ account.agency }}
      <br />
      Número: {{ account.number }}
    </Banner>
    <div class="columns mt-5">
      <div class="column is-one-quarter">
        <div class="box ml-5">
          <Level :title="`R$ ${account.balance}`" heading="Saldo" />
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
      <Table :header="tableHeader" :data="transactions" />
    </div>
    <TransactionModal
      v-if="isTransactionModalOpen"
      :close="closeransactionModal"
      :transactionType="transactionType"
      :errorMessage="errorMessage"
      :loading="buttonloading"
      @transaction="makeTransaction"
    />
  </div>
</template>

<script>
import { Banner, Level, Button, Table, TransactionModal } from "../components";
import { userService, accountService, transactionService } from "../services";

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
    const loader = this.$loading.show({
      container: this.fullPage ? null : this.$refs.formContainer,
      canCancel: true,
      onCancel: this.onCancel,
      opacity: 1,
      backgroundColor: "#acacace6",
    });
  
    await this.loadDefaultUser();
    await this.loadAccount();

    setTimeout(() => {
      loader.hide();
    }, 500);
  },

  computed: {
    userName() {
      const { user } = this.account;

      return user ? user.name : {};
    },

    transactions() {
      const { transactions } = this.account;

      return transactions
        ? transactions.sort((a, b) =>  new Date(b.date) - new Date(a.date))
        : [];
    },
  },

  data() {
    return {
      transactionType: {},
      isTransactionModalOpen: false,
      account: {},
      user: {},
      buttonloading: false,
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
      errorMessage: "",
    };
  },

  methods: {
    async loadDefaultUser() {
      this.user = await userService.getBy(1);
    },

    async loadAccount() {
      this.account = await accountService.getByUserId(this.user.id);
    },

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

    async makeTransaction(transaction) {
      this.buttonloading = true;
      const { id: accountId } = this.account;
      const { type, ...rest } = transaction;

      this.errorMessage = "";
      try {
        await transactionService[type]({ ...rest, accountId });

        this.closeransactionModal();
        this.loadAccount();
      } catch (exception) {
        const {
          response: { data },
        } = exception;
        this.errorMessage = data;
      }
      this.buttonloading = false;
    },
  },
};
</script>
<style scoped>
.box {
  min-height: 97px !important;
}
</style>