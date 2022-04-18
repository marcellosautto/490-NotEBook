import { configureStore } from "@reduxjs/toolkit";
import userSlice from "./slices/UserSlice";
import tokenSlice from "./slices/TokenSlice";

export const store = configureStore({
  reducer: {
    tokenSlice,
    userSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
