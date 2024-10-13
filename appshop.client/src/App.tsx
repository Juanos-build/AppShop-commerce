import { Routes, Route } from 'react-router-dom';
import ProductList from "./components/shop/product/ProductList";
import Cart from './components/shop/cart/Cart'
import ShoppingCart from './components/shop/cart/ShoppingCart';

function App() {
    return (
        <div className="container">
            <ShoppingCart />
            <hr />
            <Routes>
                <Route path="/" element={<ProductList />} />
                <Route path="/home" element={<ProductList />} />
                <Route path="/cart" element={<Cart />} />
            </Routes>
        </div>
    );
}

export default App;