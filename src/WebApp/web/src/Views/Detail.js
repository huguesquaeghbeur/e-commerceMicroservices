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
        <section className='grid grid-cols-2 min-h-screen' id='neueFont'>
            <aside className='col-start-1 col-end-2 m-4 bg-gray-200 h-96 flex items-center '>
                <img className='shadow-lg shadow-gray-800 mx-auto' src={detailProduct.imageFile} alt="vue du produit" />
            </aside>
            <article className='col-start-2 col-end-3 m-4'>
                <div className='font-bold text-xl' id='romanFont'>{detailProduct.name}</div>
                <form action="" method="post">
                    <label htmlFor="quantity">Quantité</label><br />
                    <input type="number" name="quantity" className='w-1/2 h-8 rounded-sm focus:border-2 focus:border-black'/>
                    <div className='font-semibold text-xl'>€ {detailProduct.price} EUR</div>
                    <div>Expédition Gratuite</div>
                    <button className='w-full h-10 bg-black text-white rounded'>
                        <p>Ajouter au panier  <FontAwesomeIcon icon={faCartShopping} className='text-base'/>
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