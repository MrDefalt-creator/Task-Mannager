import axios from "axios";

const API_URL = "https://localhost:7000";
const $api = axios.create({
    baseURL: API_URL,
    withCredentials: true
})

$api.interceptors.request.use(config => {
    config.headers.Authorization = "Bearer " + localStorage.getItem("accessToken");
    return config;
});

$api.interceptors.response.use(
    response => response,
    async error => {
        const originalRequest = error.config;
        if (error.response && error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
            try {
                const response = await $api.post(`update_jwt`, {
                });
                localStorage.setItem("accessToken", response.data.accessToken);
                originalRequest.headers.Authorization = "Bearer " + response.data.accessToken;
                return $api(originalRequest);
            } catch (refreshError) {
                console.error("Token refresh failed:", refreshError);
                return Promise.reject(refreshError);
            }
        }
        return Promise.reject(error);
    }
);

export default $api;