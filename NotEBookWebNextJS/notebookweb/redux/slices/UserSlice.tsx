import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "../Store";

const initialState = {
  user: {}
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<any>) => {
      state.user = action.payload;
    },
  },
});

export const { setUser } = userSlice.actions;

export default userSlice.reducer;
