import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    totalCount: 0,
    items: []
}

const cartSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        addProductToCart: (state, action) => {
            const { items } = state;
            const product = action.payload;
            const subTotal = product.quantity * product.price;
            const productToUpdate = items.find(i => i.productId === product.productId);
            if (productToUpdate) {
                productToUpdate.quantity = product.quantity;
                productToUpdate.subTotal = subTotal;
            }
            else {
                state.items = [...state.items, { ...product, subTotal: subTotal }];
                state.totalCount += 1;
            }
        },
        removeProductFromCart: (state, action) => {
            const productId = action.payload;
            state.totalCount -= 1;
            state.items = state.items.filter(item => item.productId !== productId);
        },
        clearCart: (state) => {
            state.items = [];
            state.totalCount = 0;
        }
    }
});

export const { addProductToCart, removeProductFromCart, clearCart } = cartSlice.actions;

export default cartSlice.reducer;