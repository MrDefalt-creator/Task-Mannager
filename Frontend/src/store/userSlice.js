import {createSlice, createAsyncThunk} from "@reduxjs/toolkit";
import UserEndpoints from "../endpoints/UserEndpoints.js";

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

const initialState = {
    userId: null,
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
}

const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        logout: (state) => {
            state.userId = null;
            state.user = null;
            state.email = null;
            localStorage.removeItem("user");
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
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
            });
    }
});

export const { logout } = userSlice.actions;
export default userSlice.reducer;

