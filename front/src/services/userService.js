import bankSystemClient from '../clients/bankSystemClient'; 

const BASE_URL = 'User';
export default {
    async getAll() {
        const { data } = await bankSystemClient.get(BASE_URL);

        return data;
    },

    async getBy(id) {
        const { data } = await bankSystemClient.get(`${BASE_URL}/${id}`);

        return data;
    },

    async create(user) {
        const { data } = await bankSystemClient.post(BASE_URL, user);

        return data;
    },

    async edit(id, user) {
        const { data } = await bankSystemClient.put(`${BASE_URL}/${id}`, user);

        return data;
    },

    async remove(id) {
        const { data } = await bankSystemClient.delete(`${BASE_URL}/${id}`);

        return data;
    },
};