import React from 'react';
import { Link } from 'react-router-dom';

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPaperPlane, faCartShopping, faUser } from '@fortawesome/free-solid-svg-icons';

const Header = () => {
    return (
        <header className='grid grid-cols-12 gap-4 h-8 bg-black text-white text-center content-center text-xs font-semibold tracking-widest' id='neueFont'>
            <div className='col-start-4 col-end-10' >
                <p>
                    <FontAwesomeIcon icon={faPaperPlane} className='text-base' />  EXPÉDITION GRATUITE
                </p>
            </div>
            <div className='col-start-10 col-end-12'>
                <Link to='/'>
                    <p>
                        <FontAwesomeIcon icon={faUser} className='text-base' /> MON COMPTE
                    </p>
                </Link>
            </div>
            <div className='col-start-12 col-end-13'>
                <Link to='/cart'>
                    <FontAwesomeIcon icon={faCartShopping} className='relative text-base' />
                    <div className="absolute inline-flex items-center justify-center w-6 h-6 text-xs text-white bg-black -top-1 right4">0</div>
                </Link>
            </div>
        </header>
    )
}
export default Header;