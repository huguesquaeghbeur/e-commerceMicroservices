import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { GetProductById } from '../Services/CatalogService';

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';


const Detail = (props) => {
    const [detailProduct, setDetailProduct] = useState();

    useEffect(() => {
        GetProductById(props.productId).then(response => {
            setDetailProduct(response.data)
        });
    }, [props]);
    console.log(detailProduct);

    if (!detailProduct) return null;

    return (
        <section className='grid grid-cols-2 min-h-screen neueFont mt-10'>
            <aside className='col-start-1 col-end-2 m-4 bg-gray-200 h-96 flex items-center shadow-lg shadow-gray-800'>
                <img className='mx-auto h-80' src={detailProduct.imageFile} alt="vue du produit" />
            </aside>
            <article className='col-start-2 col-end-3 m-4'>
                <div className='font-bold text-xl romanFont' >{detailProduct.name}</div>
                <form action="" method="post">
                    <label htmlFor="quantity">Quantité</label><br />
                    <input type="number" name="quantity" className='w-1/2 h-8 rounded-sm border-2 border-gray-200 focus:border-2 focus:border-black'/>
                    <div className='font-semibold text-xl romanFont'>€ {detailProduct.price} EUR</div>
                    <div>Expédition Gratuite</div>
                    <button className='w-full h-10 bg-black text-white rounded'>
                        <p><FontAwesomeIcon icon={faCartShopping} className='text-base mr-2'/>Ajouter au panier  
                        </p>
                    </button>
                </form>
                <div>
                    <p className='font-semibold'>Description : </p>
                    <p>{detailProduct.description}</p>
                    <p className='font-semibold'>Résumé : </p>
                    <p>{detailProduct.summary}</p>
                </div>
            </article>
        </section>
    )
}

export default function Getid() {
    const { id } = useParams()
    return (
        <Detail productId={id} />
    )
}