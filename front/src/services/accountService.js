import bankSystemClient from '../clients/bankSystemClient';
import transactionMapper from './mappers/transactionMapper';

const BASE_URL = 'Account';
export default {
    async getAll() {
        const { data } = await bankSystemClient.get(BASE_URL);

        return data;
    },

    async getBy(id) {
        const { data } = await bankSystemClient.get(`${BASE_URL}/${id}`);

        return data;
    },

    async getByUserId(userId) {
        const { data } = await bankSystemClient.get(`${BASE_URL}/User/${userId}`);

        data.transactions = data.transactions
            .map(({ transactionType, ...rest }) =>
                ({ ...rest, transactionType: transactionMapper[transactionType] })
            );

        return data;
    },

    async create(account) {
        const { data } = await bankSystemClient.post(BASE_URL, account);

        return data;
    },

    async edit(id, account) {
        const { data } = await bankSystemClient.put(`${BASE_URL}/${id}`, account);

        return data;
    },

    async remove(id) {
        const { data } = await bankSystemClient.delete(`${BASE_URL}/${id}`);

        return data;
    },
}