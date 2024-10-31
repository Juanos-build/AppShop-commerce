import { setCurrentPage } from "../../../redux/reducers/ProductSlice";
import { useAppSelector, useAppDispatch } from '../../../app/hooks';

function Pagination() {
    const dispatch = useAppDispatch();
    const { currentPage, pageSize } = useAppSelector(state => state.productItems);

    const numPages = [];
    for (let i = 1; i <= pageSize; i++) {
        numPages.push(i);
    }

    const handlePrevPage = async () => {
        dispatch(setCurrentPage(currentPage - 1));
    };

    const handleNextPage = () => {
        dispatch(setCurrentPage(currentPage + 1));
    };

    const handleSpecificPage = (page) => {
        dispatch(setCurrentPage(page));
    };

    return (      
        <nav aria-label="Page navigation example">
            <ul className="pagination justify-content-center">
                <li className={`page-item ${currentPage === 1 ? 'disabled' : ''}`}>
                    <button
                        className="page-link"
                        onClick={() => handlePrevPage()}
                    >Previous</button>
                </li>
                {
                    numPages.map(page => (
                        <li key={page} className={`${page === currentPage ? 'page-item active':''}`}>
                            <button
                                className="page-link"
                                onClick={() => handleSpecificPage(page)}
                            >{page}</button>
                        </li>
                    ))
                }
                <li className={`page-item ${currentPage >= pageSize ? 'disabled' : ''}`}>
                    <button
                        className="page-link"
                        onClick={() => handleNextPage()}
                    >Next</button>
                </li>
            </ul>
        </nav>
    )
}

export default Pagination;