import { useState, useEffect }from 'react';
import { Link } from 'react-router-dom';
import { GetProduct } from '../Services/CatalogService';

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEnvelope, faMagnifyingGlass, faChevronDown } from '@fortawesome/free-solid-svg-icons';

const Nav = () => {
    const [products, setProducts] = useState();

    useEffect(() => {
        GetProduct().then(response => {
            setProducts(response.data)
        });
    }, []);

    return (
        <nav className='grid grid-cols-8 h-12 text-center text-xs  font-semibold content-center border-b-2 border-gray-200 tracking-widest mr-3 ml-3'>
            <div className='col-start-1 col-end-2 text-xs pt-1'>
                <Link to='/'>LOGO</Link>
            </div>
            <div className='col-start-3 col-end-7 flex justify-around pt-1'>
                <Link to='/bio'>À PROPOS</Link>
                <Link to='/catalog'>BOUTIQUE</Link>
                {/* dropdown menu */}
                <button id='dropdownDelayButton' data-dropdown-toggle='dropdownDelay' data-dropdown-delay='500' data-dropdown-trigger='hover' type='button'>CATÉGORIES <FontAwesomeIcon icon={faChevronDown} /></button>
                <div id='dropdownDelay'className='z-10 hidden bg-white divide-y divide gray-200 shadow w-44'>
                    <ul className='py-2' aria-labelledby='dropdownDelayButton'>
                        {/* {products.map(product =>
                            <li key={product.id}>
                                <Link to={`/category/bycat/${product.category}`} className='block px-4 py-2 hover:bg-gray-200'>{product.category}</Link>
                            </li>
                        )} */}
                    </ul>
                </div>
                <Link to='/contact'>CONTACT</Link>
            </div>
            <div className='col-start-8 col-end-9 flex justify-around text-base'>
                <Link to='/'>
                    <FontAwesomeIcon icon={faEnvelope} />
                </Link>
                <Link to='/'>
                    <FontAwesomeIcon icon={faMagnifyingGlass} />
                </Link>
            </div>
        </nav>
    )
}
export default Nav;