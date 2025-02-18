import axios from "axios";

const API_URL = "https://localhost:7000";

const $api = axios.create({
    baseURL: API_URL,
    withCredentials: true
})


export default $api;