import { useEffect } from "react";
import { addProductToCart } from "../../../redux/reducers/CartSlice";
import { requestProducts, requestProductById } from "../../../api/ProductService";
import { useAppSelector, useAppDispatch } from '../../../app/hooks';
import { appSettings } from '../../../settings/AppSettings';
import { setProducts, updateStock } from '../../../redux/reducers/ProductSlice';
import IProduct from "../../../interfaces/IProduct";
import Swal from "sweetalert2";
import Pagination from "./Pagination";

function ProductList() {
    const dispatch = useAppDispatch();
    const { currentPage, isLoading, products } = useAppSelector(state => state.productItems);
    const { items } = useAppSelector(state => state.cart);

    useEffect(() => {
        const getProducts = async () => {
            const response = await requestProducts(currentPage, appSettings.itemPerPage);
            if (response.isOk) {
                dispatch(setProducts(response.result.products.result));
            }
            else {
                console.log(response.message);
            }
        }

        getProducts();
    }, [dispatch, currentPage]);

    const handleAddProduct = async (product: IProduct) => {

        const item = items.find(i => i.productId === product.productId);
        if (item) {
            Swal.fire({
                text: "this product is already in your shopping cart. If you want to add more of the same product you can go to your shoping cart.",
                icon: "info"
            });
            return;
        }
        else {
            const validStock = await validateStockById(product);
            if (!validStock.valid) {
                Swal.fire({
                    text: validStock.message,
                    icon: "error"
                });
                return;
            }

            Swal.fire({
                text: "your product has added to your shopping cart successfully",
                icon: "success"
            });
            const payload = { ...product, quantity: product.quantity || 1 };
            dispatch(addProductToCart(payload));
            dispatch(updateStock(payload));
        }
    }

    const validateStockById = async (product) => {
        let valid = true;
        let message = '';

        const response = await requestProductById(product.productId);
        if (response.isOk) {
            const stockProduct = response.result.productById.result.stock;
            if (product.quantity > stockProduct) {
                valid = false;
                message = `product stock in shopping cart has changed. Product name:${product.productName} current stock:${product.stock} available stock:${stockProduct}`;
            }
        }
        else {
            valid = false;
            message = `it has occurred an error fetching products stock:${response.message}`;
        }
        return {
            valid: valid,
            message: message
        };
    }

    const incrementQuantity = (product) => {
        const item = items.find(i => i.productId === product.productId);
        if (item) {
            Swal.fire({
                text: "this product is already in your shopping cart. If you want to add more of the same product you can go to your shoping cart.",
                icon: "info"
            });
            return;
        }
        else {
            if (product.quantity < product.stock) {
                const quantity = product.quantity + 1;
                const payload = { ...product, quantity: quantity };
                dispatch(updateStock(payload));
            }
        }
    }

    const decrementQuantity = (product) => {
        const item = items.find(i => i.productId === product.productId);
        if (item) {
            Swal.fire({
                text: "this product is already in your shopping cart. If you want to add more of the same product you can go to your shoping cart.",
                icon: "info"
            });
            return;
        }
        else {
            if (product.quantity > 1) {
                const quantity = product.quantity - 1;
                const payload = { ...product, quantity: quantity };
                dispatch(updateStock(payload));
            }
        }
    }

    return (
        <>
            {isLoading && (
                <>
                    <div className="row row-cols-1 row-cols-md-4 g-2">
                        {products?.map(product => (
                            <div className="card" key={product.productId}>
                                <img
                                    src={product.image || "./bagShop.png"}
                                    className="card-img-top"
                                    style={{
                                        width: "100%",
                                        height: "20vw",
                                        objectFit: "cover"
                                    }}
                                />
                                <div className="card-body">
                                    <h6 className="card-title">{product.productName}</h6>
                                    <p >Code: {product.productCode} <b>Price: ${product.price}</b>
                                        <br className="card-text"></br>
                                        <small className="text-body-secondary">
                                            {product.description}</small></p>                                                                        
                                </div>
                                <div className="row row-cols-1 row-cols-md-2 g-2">
                                    <div>
                                        <a className={product.stock === 0 ? `btn btn-secondary disabled`:`btn btn-dark`}
                                        onClick={() => handleAddProduct(product)}
                                    >
                                        Add
                                    </a>
                                    </div>
                                    <div className="text-end">
                                    <button type="button" className="btn btn-secondary btn-sm" onClick={() => decrementQuantity(product)}>-</button>
                                    <input className="col-md-2" readOnly value={product.quantity || 0}></input>
                                    <button type="button" className="btn btn-secondary btn-sm" onClick={() => incrementQuantity(product)}>+</button>
                                    </div>
                                </div>
                                <div className="card-footer">
                                    <small className="text-success"><b> {product.stock} in stock</b></small>                                    
                                </div>
                            </div>
                        )
                        )}
                    </div>
                    <Pagination />
                </>
            )}
        </>
    );
}

export default ProductList;
