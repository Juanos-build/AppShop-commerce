import { Link } from 'react-router-dom';
import { useAppSelector } from '../../../app/hooks';

function ShoppingCart() {
    const { totalCount } = useAppSelector(state => state.cart);

    return (
        <div className="d-flex py-4">
            <Link className="btn btn-info mx-2" to="/home">Home</Link>
            <div className="ms-auto">
                <Link className="btn btn-secondary position-relative" to="/cart">
                    Cart
                    <span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-primary">
                        {totalCount}
                        <span className="visually-hidden">products in cart</span>
                    </span>
                </Link>
            </div>
        </div>
    )
}

export default ShoppingCart;