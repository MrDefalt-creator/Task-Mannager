import {createSlice, createAsyncThunk} from "@reduxjs/toolkit";
import UserEndpoints from "../endpoints/UserEndpoints.js";
import storage from "redux-persist/lib/storage";
import {persistReducer} from "redux-persist";

export const loginUser = createAsyncThunk(
    "user/login",
    async({email, password, rememberMe}, {rejectWithValue}) => {
        try {
                const response = await UserEndpoints.login(email, password, rememberMe);
                localStorage.setItem("user", JSON.stringify(response.data));
                return response.data;
        } catch (error) {
            return rejectWithValue(error.response?.data.message || "Ошибка авторизации");
        }
    }
);
export const registerUser = createAsyncThunk(
    'user/register',
    async({username,email,password}, {rejectWithValue}) => {
        try {
           const response = await UserEndpoints.register(username,email,password);
           console.log(response);
           localStorage.setItem("user", JSON.stringify(response.data));
           return response.data;
        } catch (error) {
            return rejectWithValue(error.response?.data.message || "Ошибка регистрации");
        }
    }
);
const initialState = {
    userId: null,
    accessToken: null,
    user: null,
    email: null,
    loading: false,
    error: null
};
const savedUser = JSON.parse(localStorage.getItem("user"));
if (savedUser) {
    initialState.userId = savedUser.userId;
    initialState.user = savedUser.username;
    initialState.email = savedUser.email;
    initialState.accessToken = savedUser.accessToken;

}
const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        logout: (state) => {
            state.userId = null;
            state.user = null;
            state.email = null;
            localStorage.clear();
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginUser.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(loginUser.fulfilled, (state, action) => {
                state.loading = false;
                state.userId = action.payload.userId;
                state.user = action.payload.username;
                state.email = action.payload.email;
                localStorage.setItem("accessToken", action.payload.accessToken);
                localStorage.removeItem("user");
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
            })
            .addCase(registerUser.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(registerUser.fulfilled, (state, action) => {
                state.loading = false;
                state.userId = action.payload.userId;
                state.user = action.payload.username;
                state.email = action.payload.email;
                localStorage.setItem("accessToken", action.payload.accessToken);
                localStorage.removeItem("user");
            })
            .addCase(registerUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
            });
    }
});

const persistConfig = {
    key: 'user',
    storage,
    whitelist: ["userId", "user", "email"]
}
const persistedReducer = persistReducer(persistConfig, userSlice.reducer);
export const { logout } = userSlice.actions;
export default persistedReducer;

