import { removeProductFromCart, addProductToCart, clearCart } from '../../../redux/reducers/CartSlice';
import { useAppSelector, useAppDispatch } from '../../../app/hooks';
import { requestProductById } from '../../../api/ProductService';
import { addOrder } from '../../../api/OrderService';
import { useState, ChangeEvent } from 'react';
import ICustomer from '../../../interfaces/ICustomer';
import { appSettings } from '../../../settings/AppSettings';
import Swal from "sweetalert2";
import { useNavigate } from 'react-router-dom';

const initialCustomer = {
    name: "",
    email: "",
    address: ""
}

function Cart() {
    const dispatch = useAppDispatch();
    const { items } = useAppSelector(state => state.cart);
    const [customer, setCustomer] = useState<ICustomer>(initialCustomer);
    const navigate = useNavigate();

    const handleRemoveProduct = (productId) => dispatch(removeProductFromCart(productId));

    const incrementQuantity = (product) => {
        if (product.quantity < product.stock) {
            const quantity = product.quantity + 1;
            const payload = { ...product, quantity: quantity };
            dispatch(addProductToCart(payload));
        }
    }

    const decrementQuantity = (product) => {
        if (product.quantity > 1) {
            const quantity = product.quantity - 1;
            const payload = { ...product, quantity: quantity };
            dispatch(addProductToCart(payload));
        }
    }

    const validateStock = async () => {
        let valid = true;
        let message = '';
        for (const product of items) {
            const response = await requestProductById(product.productId);
            if (response.isOk) {
                const stockProduct = response.result.productById.result.stock;
                if (product.quantity > stockProduct) {
                    valid = false;
                    message = `product stock in shopping cart has changed. Product name: ${product.productName}, current quantity: ${product.quantity} available stock: ${stockProduct}`;
                }
            }
            else {
                valid = false;
                message = `it has occurred an error fetching products stock:${response.message}`;
            }
        }
        return {
            valid: valid,
            message: message
        };
    }

    const handleProcessOrder = async () => {
        try {
            if (items.length === 0 || customer.name.length === 0 || customer.email.length === 0 || customer.address.length === 0) {
                Swal.fire({
                    text: "You must enter your email, name and bill address to complete the order",
                    icon: "warning"
                });
                return;
            }

            const validStock = await validateStock();
            if (!validStock.valid) {
                Swal.fire({
                    text: validStock.message,
                    icon: "error"
                });
                return;
            }            

            const order = {
                customer: customer,
                products: items
            };

            const response = await addOrder(order);
            if (response.isOk) {
                Swal.fire({
                    text: "your order has been processed successfully",
                    icon: "success"
                });
                dispatch(clearCart());
                setCustomer(initialCustomer);
                navigate(appSettings.initialWebPage)
            }
            else {
                Swal.fire({
                    title: "Something was wrong",
                    text: `it has occurred an error processing the order. Error:${response.result}`,
                    icon: "error"
                });
                console.log(response.result);
            }
        } catch (error) {
            console.error('Error processing order:', error);
        }
    };

    const inputChangeValue = (event: ChangeEvent<HTMLInputElement>) => {
        const inputName = event.target.name;
        const inputValue = event.target.value;

        setCustomer({ ...customer, [inputName]: inputValue })
    }

    const total = items.reduce((total, item) => total + (item.price * item.quantity), 0)

    return (
        <>
            <h4>My shopping cart</h4>
            {items.length === 0 ? (
                <>
                    <label className="form-label">Your cart is empty.</label>
                </>
            ) : (
                <>
                    <div className="row row-cols-2 row-cols-md-2 g-7">
                            <div className="card w-80 mb-2" style={{ width: "70%" }}>
                            <table className="table">
                                <thead>
                                    <tr>
                                        <th scope="col">Product</th>
                                        <th scope="col">Price</th>
                                        <th scope="col">Quantity</th>
                                        <th scope="col">Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {items?.map(product => {
                                        return (
                                            <tr key={product.productId}>
                                                <td scope="row">{product.productName}</td>
                                                <td scope="row">{product.price}</td>
                                                <td scope="row">
                                                    <button type="button" className="btn btn-secondary btn-sm" onClick={() => decrementQuantity(product)}>-</button>
                                                    <input className="col-md-1" readOnly value={product.quantity}></input>
                                                    <button type="button" className="btn btn-secondary btn-sm" onClick={() => incrementQuantity(product)}>+</button>
                                                </td>
                                                <th scope="row">{product.subTotal}</th>
                                                <td scope="row"><button className="btn btn-secondary" onClick={() => handleRemoveProduct(product.productId)}>remove</button></td>
                                            </tr>
                                        )
                                    })}
                                </tbody>
                            </table>
                            </div>
                            <div className="card w-20 text-end" style={{ width:"30%" }}>
                            <div className="card-body">
                                <h5 className="card-title">Shopping cart details</h5>
                                <p>Items | {items.length} Units
                                    <br className="card-text"></br>Total ${total}
                                </p>
                                <a className="btn btn-success"
                                    onClick={() => handleProcessOrder()}
                                >
                                    Process order
                                </a>
                            </div>
                        </div>
                    </div>
                    <h4>User details</h4>
                    <div className="row g-3 align-items-center">
                        <div className="col-auto">
                            <label className="form-label">Name</label>
                            <input type="text" className="form-control" name="name" onChange={inputChangeValue} value={customer.name} />
                        </div>
                        <div className="col-auto">
                            <label className="form-label">Email address</label>
                            <input type="email" className="form-control" name="email" aria-describedby="emailHelp" onChange={inputChangeValue} value={customer.email} />
                        </div>
                        <div className="col-auto">
                            <label className="form-label">Bill address</label>
                            <input type="text" className="form-control" name="address" onChange={inputChangeValue} value={customer.address} />
                        </div>
                    </div>
                </>
            )}
        </>
    )
}

export default Cart;