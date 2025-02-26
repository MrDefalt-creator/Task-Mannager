import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./userSlice";
import { persistStore } from "redux-persist";

export const store = configureStore({
    reducer: {
        user: userReducer
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
