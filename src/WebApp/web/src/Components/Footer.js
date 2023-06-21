import React from 'react';

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCopyright } from '@fortawesome/free-regular-svg-icons';

const Footer = () => {
    return (
        <footer className='bg-black text-gray-400 text-center content center text-xs' id='neueFont'>
            <p>Copyright 2023 <FontAwesomeIcon icon={faCopyright} /> Hugues</p>
        </footer>
    )
}
export default Footer;