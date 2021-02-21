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

    async getByAccountId(accountId) {
        const { data } = await bankSystemClient.get(`${BASE_URL}/Account/${accountId}`);

        return data;
    },

    async create(transaction) {
        const { data } = await bankSystemClient.post(BASE_URL, transaction);

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