import React from 'react';
import {Formik, Form, Field,} from 'formik';
import * as Yup from 'yup';

import { CreateProduct } from '../Services/CatalogService';

const Product = () => {
    

    return (
        <main>
            <section>
                <article>
                    <h2>Créer produit</h2>
                    <Formik
                        initialValues={{
                            name: '',
                            category: '',
                            summary: '',
                            description: '',
                            imageFile: '',
                            price: ''
                        }}
                        validationSchema={Yup.object({
                            name: Yup.string().required(),
                            category: Yup.string().required(),
                            summary: Yup.string().required(),
                            description: Yup.string().required(),
                            imageFile: Yup.string().required(),
                            price: Yup.number().required(),                        
                        })}
                        onSubmit={(data) => 
                        {
                            console.log(JSON.stringify(data));
                            CreateProduct(data)
                                .then(response => {
                                    console.log(response.data);
                                })
                                .catch(error => {
                                    console.log(error);
                                })
                        }}
                    >
                    <Form>
                        <label htmlFor='name'>
                            Nom du produit
                        </label>
                        <Field
                            name='name'
                            type='text'
                        />
                        <label htmlFor='category'>
                            Catégorie
                        </label>
                        <Field
                            name='category'
                            type='text'
                        />
                        <label htmlFor='summary'>
                            Résumé
                        </label>
                        <Field
                            name='summary'
                            type='text'
                        />
                        <label htmlFor='description'>
                            Description
                        </label>
                        <Field
                            name='description'
                            type='text'
                        />
                        <label htmlFor='imageFile'>
                            Image
                        </label>
                        <Field
                            name='imageFile'
                            type='text'
                        />
                        <label htmlFor='price'>
                            Prix
                        </label>
                        <Field
                            name='price'
                            type='number'
                        />
                        <button type='submit'>Valider</button>
                    </Form>   
                    </Formik>
                </article>
            </section>
        </main>
    )
}

export default Product;