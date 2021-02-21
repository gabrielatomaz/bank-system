import axios from 'axios';

export default axios.create({
    baseURL: process.env.VUE_APP_BANK_SYSTEM_URL,
});