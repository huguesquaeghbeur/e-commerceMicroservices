import React, { useState } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

import { Login } from '../Services/UserService';

import { faEye, faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


const LoginForm = (props) => {
    const [values, setValues] = useState({});
    const [showPassword, setShowPassword] = useState('password');
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/;

    const changePassword = () => {
        if (showPassword === 'password') {
            return setShowPassword('text');
        }
        else {
            return setShowPassword('password');
        }
    };
    return (
        <article className="mt-4 mx-8 ">
            <h2 className="border-b-2 border-inherit my-4 romanFont">CONNEXION</h2>
            <Formik
                initialValues={{ email: '', password: '' }}
                validationSchema={Yup.object({
                    email: Yup.string()
                        .email('Adresse mail invalide')
                        .required(),
                    password: Yup.string()
                        .required('Ce champ est obligatoire')
                        .min(8, "minimum 8 caractéres")
                        .matches(regex, "Mot de passe incorrect")
                })}
                onSubmit={(data) => {
                    const formData = new FormData();
                    formData.append('email', data.email);
                    formData.append('password', data.password);

                    setTimeout(() => {
                        //a supprimé
                        console.log(data);
                        Login(formData)
                            .then(response => {
                                //a supprimé
                                console.log(response.data);
                                setValues(response.data);
                                console.log(values.token);
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
                        <button onClick={props.change} className='text-sm italic'>Mot de passe oublié?</button>
                    </div>
                    <button type='submit' className='w-full h-10 bg-black text-white rounded my-6'><FontAwesomeIcon icon={faLock} className='mr-2' />Se connecter</button>
                </Form>
            </Formik>
        </article>
    )
}
export default LoginForm;