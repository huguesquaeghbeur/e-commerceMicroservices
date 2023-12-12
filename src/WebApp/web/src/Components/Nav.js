import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { GetProduct } from '../Services/CatalogService';

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEnvelope, faMagnifyingGlass, faChevronDown, faCircleXmark } from '@fortawesome/free-solid-svg-icons';

import logo from '../Assets/Images/logo.png'

const Nav = () => {
    const [products, setProducts] = useState();
    let categories;
    let cat = [];

    useEffect(() => {
        GetProduct().then(response => {
            setProducts(response.data)
        });
    }, []);

    function onlyUnique(value, index, array) {
        return array.indexOf(value) === index;
      }
    
    // products.forEach(product => {
        
    //     cat.push(product.category);
    //     categories = cat.filter(onlyUnique);
    // }); 
      
    return (
        <nav className='grid grid-cols-8 h-12 text-center text-xs  font-semibold content-center border-b-2 border-gray-200 tracking-widest align-middle mt-3 mr-3 ml-3 romanFont'>
            <div className='col-start-1 col-end-2 text-xs pt-1'>
                <Link to='/'>
                    <img src={logo} alt='Notre logo trop stylé' className='h-6 ml-6' />
                </Link>
            </div>
            <div className='col-start-3 col-end-7 flex justify-around pt-1'>
                <Link to='/bio'>À PROPOS</Link>
                <Link to='/catalog'>BOUTIQUE</Link>
                {/* dropdown menu */}
                <button id='dropdownDelayButton' data-dropdown-toggle='dropdownDelay' data-dropdown-delay='500' data-dropdown-trigger='hover' type='button' className='mb-2'>CATÉGORIES <FontAwesomeIcon icon={faChevronDown} className='ml-2' /></button>
                <div id='dropdownDelay' className='z-10 hidden bg-white divide-y divide gray-200 shadow-lg shadow-gray-400'>
                    <ul className='py-2' aria-labelledby='dropdownDelayButton'>
                        {/* {categories.map(category => 
                            <li key={category}>
                                <Link to={`/category/bycat/${category}`} className='block px-4 py-2 hover:bg-gray-200 base'>{category}</Link>
                            </li>
                        )} */}
                    </ul>
                </div>
                <Link to='/product'>CONTACT</Link>
            </div>
            <div className='col-start-8 col-end-9 flex justify-around text-base'>
                <Link to='/'>
                    <FontAwesomeIcon icon={faEnvelope} />
                </Link>
                <button data-modal-target="defaultModal" data-modal-toggle="defaultModal" type="button" className='mb-1'>
                    <FontAwesomeIcon icon={faMagnifyingGlass} />
                </button>
                <div id="defaultModal" tabIndex="-1" aria-hidden="true" className="fixed bg-black/60 top-0 left-0 right-0 z-50 hidden w-full p-4 overflow-x-auto overflow-y-auto md:inset-0 h-[calc(100%-1rem)] h-screen">

                    <div className="w-full max-w-2xl max-h-full">
                        {/* modal content */}
                        <div className='relative border-b-2'>
                            <input type='text' className='w-11/12 bg-white/0  focus:border-none placeholder:text-white text-white neueFont' placeholder='Rechercher'>
                            </input>
                            <FontAwesomeIcon icon={faMagnifyingGlass} className='text-white' />
                        </div>
                        <button type="button" data-modal-hide="defaultModal" className="absolute top-20 right-10">
                            <FontAwesomeIcon icon={faCircleXmark} className="h-8 text-white" />
                        </button>
                    </div>
                </div>

            </div>
        </nav>
    )
}
export default Nav;