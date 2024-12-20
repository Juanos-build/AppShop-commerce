import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    products: [],
    pageSize: 0,
    totalProducts: 0,
    currentPage: 1,
    isLoading: false,
    isError: false
};

const productSlice = createSlice({
    name: 'productItems',
    initialState: initialState,
    reducers: {
        setCurrentPage: (state, action) => {
            state.currentPage = action.payload;
        },
        setProducts: (state, action) => {
            const { products, currentPage, totalProducts, pageSize } = action.payload;
            state.products = products;
            state.currentPage = currentPage;
            state.totalProducts = totalProducts;
            state.pageSize = Math.ceil(totalProducts / pageSize);
            state.isLoading = true;
        },
        updateStock: (state, action) => {
            const { products } = state;
            const product = action.payload;
            const productToUpdate = products.find(i => i.productId === product.productId);            
            productToUpdate.quantity = product.quantity;
        }
    }
});

export const { setCurrentPage, setProducts, updateStock } = productSlice.actions;

export default productSlice.reducer;