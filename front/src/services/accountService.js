import bankSystemClient from '../clients/bankSystemClient'; 

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