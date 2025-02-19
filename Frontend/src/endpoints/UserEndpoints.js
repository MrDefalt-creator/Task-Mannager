import $api from './api';

export default class UserEndpoints {

    static async register(userName, email, password) {
        return await $api.post("/register", {userName, email, password});
    }

    static async login(email, password) {
        return await $api.post("/login", {email, password});
    }
}