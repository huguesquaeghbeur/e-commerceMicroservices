import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

import { Login } from '../Services/UserService';

import { faEye, faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { faLock, faUser, faArrowLeft, faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


const User = () => {
    const [values, setValues] = useState({});
    const [showPassword, setShowPassword] = useState('password');
    const [change, setChange] = useState(true);

    const changePassword = () => {
        if (showPassword === 'password') {
            return setShowPassword('text');
        }
        else {
            return setShowPassword('password');
        }
    };

    useEffect(() => {

    }, [change]);

    return (
        <main className='grid grid-cols-2 mt-10'>
            <section className=" border-2 border-inherit mx-4 my-12 bg-gray-100 shadow-lg shadow-gray-400">
                {change ?
                    (
                        <article className="mt-4 mx-8 ">
                            <h2 className="border-b-2 border-inherit my-4 romanFont">CONNEXION</h2>
                            <Formik
                                initialValues={{ email: '', password: '' }}
                                validationSchema={Yup.object({
                                    email: Yup.string()
                                        .email('Adresse mail invalide')
                                        .required(),
                                    password: Yup.string()
                                        .max(25, 'Dois contenir 25 caractéres maximum')
                                        .min(8, 'Dois contenir minimun 8 caractéres')
                                        .required('Ce champ est obligatoire'),
                                })}
                                onSubmit={(data) => {
                                    setTimeout(() => {
                                        //a supprimé
                                        console.log(data);
                                        Login(data)
                                            .then(response => {
                                                //a supprimé
                                                console.log(response.data);
                                                setValues(response.data);
                                                localStorage.setItem('token', `${values.token}`);
                                            })
                                            .catch(error => {
                                                console.log(error)
                                            })
                                    }, 400);
                                }}
                            >
                                <Form className='neueFont'>
                                    <div className='w-1/2 block'>
                                        <label htmlFor='email'>
                                            Email
                                        </label>
                                        <Field
                                            name='email'
                                            type='email'
                                            placeholder='Email'
                                            className='w-full my-4 border-2 border-gray-200'
                                        />
                                        <p className='text-red-500 text-xs italic'>
                                            <ErrorMessage name='email' />
                                        </p>
                                        <label htmlFor='password' className='mt-4'>
                                            Mot de passe
                                        </label>
                                        <Field
                                            name='password'
                                            type={showPassword}
                                            placeholder='Mot de passe'
                                            className='w-full my-4 border-2 border-gray-200'
                                        />
                                        <span className='relative'>
                                            <button type='button'
                                                className='absolute inset-y-0 right-3'
                                                onClick={changePassword}>
                                                {showPassword === 'password' ? (<FontAwesomeIcon icon={faEye} />) : (<FontAwesomeIcon icon={faEyeSlash} />)}
                                            </button>
                                        </span>
                                        <p className='text-red-500 text-xs italic'>
                                            <ErrorMessage name='password' />
                                        </p>
                                        <button onClick={() => setChange(false)} className='text-sm italic'>Mot de passe oublié?</button>
                                    </div>
                                    <button type='submit' className='w-full h-10 bg-black text-white rounded my-6'><FontAwesomeIcon icon={faLock} className='mr-2' />Se connecter</button>
                                </Form>
                            </Formik>
                        </article>
                    ) : (
                        <article className="mt-4 mx-8">
                            <h2 className="border-b-2 border-inherit my-4 romanFont">RÉINITIALISER VOTRE MOT DE PASSE</h2>
                            <p className="my-4 neueFont">Nous vous ferons parvenir un courriel pour réinitialiser votre mot de passe.</p>
                            <Formik
                                initialValues={{ email: '' }}
                                validationSchema={Yup.object({
                                    email: Yup.string()
                                        .email('Adresse mail invalide')
                                        .required(),
                                })}
                                onSubmit={(data) => {
                                    setTimeout(() => {
                                        //a supprimé
                                        console.log(JSON.stringify(data));
                                        Login(data)
                                            .then(response => {
                                                //a supprimé
                                                console.log(response.data);
                                                setValues(response.data);
                                                localStorage.setItem('token', `${values.token}`);
                                            })
                                            .catch(error => {
                                                console.log(error)
                                            })
                                    }, 400);
                                }}
                            >
                                <Form className='neueFont'>
                                    <div className='w-1/2 block'>
                                        <label htmlFor='email'>
                                            Email
                                        </label>
                                        <Field
                                            name='email'
                                            type='email'
                                            // id='email'
                                            placeholder='Email'
                                            className='w-full my-4 border-2 border-gray-200'
                                        />
                                        <p className='text-red-500 text-xs italic'>
                                            <ErrorMessage name='email' />
                                        </p>
                                    </div>
                                    <button type='submit' className='w-full h-10 bg-black text-white rounded my-6'><FontAwesomeIcon icon={faEnvelope} className='mr-2' />Soumettre</button>
                                </Form>
                            </Formik>
                            
                                <button onClick={() => setChange(true)}className='w-full h-8 bg-black text-white rounded my-6 neueFont'>
                                    <FontAwesomeIcon icon={faArrowLeft} className='mr-2' />Annuler
                                </button>
                            
                        </article>
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