import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import Password from '../Components/Password';
import Login from '../Components/Login';

import { faEye, faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { faLock, faUser, faArrowLeft, faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


const User = () => {
    const [change, setChange] = useState(true);

    useEffect(() => {

    }, [change]);
    
    return (
        <main className='grid grid-cols-2 mt-10'>
            <section className=" border-2 border-inherit mx-4 my-12 bg-gray-100 shadow-lg shadow-gray-400">
                {change ?
                    (
                        <Login change={() => setChange(false)} />
                    ) : (
                        <Password change={() => setChange(true)} />
                    )}
            </section>
            <section className="border-2 border-inherit mx-4 my-12 bg-gray-100 shadow-lg shadow-gray-400">
                <article className="mt-4 mx-8 neueFont">
                    <h2 className="border-b-2 border-inherit my-4 romanFont">CRÉER UN COMPTE</h2>
                    <p id='neueFont'>En vous créant un compte, vous serez en mesure de procéder à vos achats plus rapidement et de créer votre liste de souhait.</p>
                    <Link to='/client/signin' >
                        <button className='w-full h-10 bg-black text-white rounded my-6' id='neueFont'>
                            <FontAwesomeIcon icon={faUser} className='mr-2' />Créer
                        </button>
                    </Link>
                </article>
            </section>
        </main>
    )
}
export default User;