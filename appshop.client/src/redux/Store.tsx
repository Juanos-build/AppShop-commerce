import { configureStore } from '@reduxjs/toolkit'
import ProductReducer from './reducers/ProductSlice';
import CartReducer from './reducers/CartSlice';

const reducer = configureStore({
    reducer: {
        productItems: ProductReducer,
        cart: CartReducer
    }
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof reducer.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof reducer.dispatch

export default reducer;
