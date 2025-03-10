import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import TaskEndpoints from "../endpoints/TaskEndpoints.js";
import * as response from "autoprefixer";



export const getTask = createAsyncThunk(
    'task/getTask',
    async ({id}, {rejectWithValue}) => {
        try {
            const response = await TaskEndpoints.getTask(id);
            localStorage.setItem('task', JSON.stringify(response.data));
            return response.data;
        } catch (error) {
            return rejectWithValue(error.response?.data.message || "Задача не найдена");
        }
    }
);

export const createTask = createAsyncThunk(
    'task/createTask',
    async ({title, description, mustFinishAt, navigate, dispatch}, {rejectWithValue}) => {
        try {
            const response = await TaskEndpoints.createTask(title, description, mustFinishAt);
            dispatch(getTask({id: response.data.id}));
            navigate('taskinfo');
            return response.data;
        } catch (error) {
            return rejectWithValue(error.response?.data.message || "Задача не найдена");
        }
    }
)

export const updateTask = createAsyncThunk(
    'task/updateTask',
    async ({id, title, description, mustFinishAt,navigate},{rejectWithValue}) => {
        try{
            await TaskEndpoints.updateTask(id, title, description, mustFinishAt);
            navigate('/dashboard/');
        } catch (error){
            error.preventDefault();
            return rejectWithValue(error.response?.data.message || "Задача не найдена");
        }
    }
);

export const deleteTask = createAsyncThunk(
    'task/deleteTask',
    async ({id,navigate}, {rejectWithValue}) => {
        try {
            await TaskEndpoints.deleteTask(id);
            navigate('/dashboard/');
        } catch (error){
            error.preventDefault();
            return rejectWithValue(error.response?.data.message || "Удаление не удалось");
        }
    }
)

const initialState = {
    taskId: null,
    title:null,
    description:null,
    createdAt:null,
    mustFinish:null,
    loading: false,
    error: null,
};

const savedTask = JSON.parse(localStorage.getItem('task'));
if (savedTask) {
    initialState.taskId = savedTask.id;
    initialState.title = savedTask.title;
    initialState.description = savedTask.description;
    initialState.createdAt = savedTask.createdAt;
    initialState.mustFinish = savedTask.mustFinish;
}

const taskSlice = createSlice({
    name: "task",
    initialState,
    reducers: {

    },
    extraReducers:(builder)=> {
        builder
            .addCase(getTask.pending, (state)=>{
                state.loading = true;
                state.error = null;
            })
            .addCase(getTask.fulfilled, (state, action)=>{
                state.loading = false;
                state.taskId = action.payload.id;
                state.title = action.payload.title;
                state.description = action.payload.description;
                state.createdAt = action.payload.createdAt;
                state.mustFinish = action.payload.mustFinish;
                localStorage.removeItem("task");

            })
            .addCase(getTask.rejected, (state, action)=>{
                state.loading = false;
                state.error = action.payload;
            });

    }
});

export default taskSlice.reducer;