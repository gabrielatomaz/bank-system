import bankSystemClient from '../clients/bankSystemClient'; 

const BASE_URL = 'Transaction';
export default {
    async getAll() {
        const { data } = await bankSystemClient.get(BASE_URL);

        return data;
    },

    async getBy(id) {
        const { data } = await bankSystemClient.get(`${BASE_URL}/${id}`);

        return data;
    },

    async create(transaction) {
        const { data } = await bankSystemClient.post(BASE_URL, transaction);

        return data;
    },

    async deposit(transaction) {
        const { data } = await bankSystemClient.post(`${BASE_URL}/Deposit`, transaction);

        return data;
    },

    async withdraw(transaction) {
        const { data } = await bankSystemClient.post(`${BASE_URL}/Withdraw`, transaction);

        return data;
    },

    async payment(transaction) {
        const { data } = await bankSystemClient.post(`${BASE_URL}/Payment`, transaction);

        return data;
    },

    async edit(id, transaction) {
        const { data } = await bankSystemClient.put(`${BASE_URL}/${id}`, transaction);

        return data;
    },

    async remove(id) {
        const { data } = await bankSystemClient.delete(`${BASE_URL}/${id}`);

        return data;
    },
}