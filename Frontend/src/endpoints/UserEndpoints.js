import $api from '../http/index.js';

export default class UserEndpoints {

    static async register(userName, email, password) {
        return await $api.post("/register", {userName, email, password});
    }

    static async login(email, password, rememberMe) {
        return await $api.post("/login", {email, password, rememberMe});
    }
}