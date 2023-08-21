import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

import { Login } from '../Services/UserService';

import { faArrowLeft, faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const Password = () => {
    const [values, setValues] = useState({});

    return (
        <article className="mt-4 mx-8">
            <h2 className="border-b-2 border-inherit my-4">RÉINITIALISER VOTRE MOT DE PASSE</h2>
            <p id='neueFont' className="my-4">Nous vous ferons parvenir un courriel pour réinitialiser votre mot de passe.</p>
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
                <Form id='neueFont'>
                    <div className='w-1/2 block'>
                        <label htmlFor='email'>
                            Email
                        </label>
                        <Field
                            name='email'
                            type='email'
                            placeholder='Email'
                            className='w-full my-4'
                        />
                        <p className='text-red-500 text-xs italic'>
                            <ErrorMessage name='email' />
                        </p>
                    </div>
                    <button type='submit' className='w-full h-10 bg-black text-white rounded my-6'><FontAwesomeIcon icon={faEnvelope} className='mr-2' />Soumettre</button>
                </Form>
            </Formik>
            <Link to='/client' >
                <button className='w-full h-8 bg-black text-white rounded my-6' id='neueFont'>
                    <FontAwesomeIcon icon={faArrowLeft} className='mr-2' />Annuler
                </button>
            </Link>
        </article>
    )
}
export default Password;