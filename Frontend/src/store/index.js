import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./userSlice";
import { persistStore } from "redux-persist";
import taskReducer from "./taskSlice";

export const store = configureStore({
    reducer: {
        user: userReducer,
        task: taskReducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: {
                ignoredActions: [
                    'persist/PERSIST',
                    'persist/REHYDRATE',
                    'persist/FLUSH',
                    'persist/PAUSE',
                    'persist/PURGE',
                    'persist/REGISTER'
                ],
            },
        }),
});

export const persistor = persistStore(store);
