import $api from '../http/index.js';

export default class UserEndpoints {

    static async register(username, email, password) {
        return await $api.post("/register", {username, email, password});
    }

    static async login(email, password, rememberMe) {
        return await $api.post("/login", {email, password, rememberMe});
    }

    static async updateJwt(){
        return await $api.post("/update_jwt", {})
    }
}