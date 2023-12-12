import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

import { Signin } from '../Services/UserService';

import { faEye, faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { faUser, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const SigninPage = () => {
    const [values, setValues] = useState({});
    const [showPassword, setShowPassword] = useState('password');

    const changePassword = () => {
        if (showPassword === 'password') {
            return setShowPassword('text');
        }
        else {
            return setShowPassword('password');
        }
    };

    return (
        <main>
            <section className='w-1/2 border-2 border-inherit mx-auto my-12 bg-gray-100 shadow-lg shadow-gray-400'>
                <article className="mt-4 mx-8">
                    <h2 className="border-b-2 border-inherit my-4 text-center romanFont">CRÉER UN COMPTE</h2>
                    <Formik
                        initialValues={{ firstName: '', lastName: '', email: '', password: '' }}
                        validationSchema={Yup.object({
                            firstName: Yup.string()
                                .required('Ce champ est obligatoire'),
                            lastName: Yup.string()
                                .required('Ce champ est obligatoire'),
                            email: Yup.string()
                                .email('Adresse mail invalide')
                                .required('Ce champ est obligatoire'),
                            password: Yup.string()
                                .max(25, 'Dois contenir 25 caractéres maximum')
                                .min(8, 'Dois contenir minimun 8 caractéres')
                                .required('Ce champ est obligatoire'),
                        })}
                        onSubmit={(data) => {
                            const formData = new FormData();
                            formData.append('firstName', data.firstName);
                            formData.append('lastName', data.lastName);
                            formData.append('email', data.email);
                            formData.append('password', data.password);

                            setTimeout(() => {
                                //a supprimé
                                console.log(JSON.stringify(data));
                                Signin(formData)
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
                            <label htmlFor='firstName' >
                                Prénom
                                <Field
                                    name='firstName'
                                    type='text'
                                    placeholder='Prénom'
                                    className='w-full my-4 border-2 border-gray-200'
                                    id='firstName'
                                    autoComplete='off'
                                />
                            </label>
                            <label htmlFor='lastName'>
                                Nom
                                <Field
                                    name='lastName'
                                    type='text'
                                    placeholder='Nom'
                                    className='w-full my-4 border-2 border-gray-200'
                                    id='lastName'
                                />
                            </label>
                            <label htmlFor='email'>
                                Email
                                <Field
                                    name='email'
                                    type='email'
                                    placeholder='Email'
                                    className='w-full my-4 border-2 border-gray-200'
                                    id='email'
                                />
                            </label>
                            <p className='text-red-500 text-xs italic'>
                                <ErrorMessage
                                    name='email'
                                />
                            </p>
                            <label htmlFor='password' className='mt-4'>
                                Mot de passe
                                <Field
                                    name='password'
                                    type={showPassword}
                                    placeholder='Mot de passe'
                                    className='w-full my-4 border-2 border-gray-200'
                                    id='password'
                                />
                            </label>
                            <span className='relative'>
                                <button
                                    type='button'
                                    className='absolute inset-y-0 right-3'
                                    onClick={changePassword}>
                                    {showPassword === 'password' ? (<FontAwesomeIcon icon={faEye} />) : (<FontAwesomeIcon icon={faEyeSlash} />)}
                                </button>
                            </span>
                            <p className='text-red-500 text-xs italic'>
                                <ErrorMessage name='password' />
                            </p>
                            <button type='submit' className='w-full h-10 bg-black text-white rounded my-6'><FontAwesomeIcon icon={faUser} className='mr-2' />Se connecter</button>
                        </Form>
                    </Formik>
                    <Link to='/catalog'>
                        <p className='text-base neueFont'>
                            <FontAwesomeIcon icon={faArrowLeft} className='mr-2' />Retour à la boutique
                        </p>
                    </Link>
                </article>
            </section>
        </main>
    )
}
export default SigninPage;