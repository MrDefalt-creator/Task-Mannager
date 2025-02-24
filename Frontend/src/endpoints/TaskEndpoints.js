import $api from "../http/index.js";

export default class TaskEndpoints {
    static async getTasks(){
        return await $api.get("/tasks");
    }

    static async getTask(id){
        return await $api.get(`/tasks/${id}`);
    }

    static async createTask(title, description = null, mustFinishAt){
        return await $api.post('/tasks', {title, description, mustFinishAt});
    }

    static async updateTask(id, title = null, description = null, mustFinishAt = null){
        return await $api.patch(`/tasks/${id}`, {title, description, mustFinishAt});
    }

    static async deleteTask(id){
        return await $api.delete(`/tasks/${id}`);
    }
}