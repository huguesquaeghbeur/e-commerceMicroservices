import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { GetProduct } from '../Services/CatalogService';

const Catalog = () => {
    const [products, setProducts] = useState();

    useEffect(() => {
        GetProduct().then(response => {
            setProducts(response.data)
        });
    }, []);

    if (!products) return null;

    return (
        <section className="grid grid-flow-row gap-8 sm:grid-cols-1 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 mb-3">
            {products.map(product =>
                <Link to={`/catalog/${product.id} `} key={product.id} >
                    <div key={product.id} className='py-4 px-4 h-70 bg-gray-100 overflow-hidden shadow-lg shadow-gray-400 duration-300 hover:-translate-y-2' id='#romanFont'>
                        <img className='w-full h-40' src={product.imageFile} alt="Nos appareils" />
                        <div className='items-center'>
                            <div className='font-bold text-xl text-center mb-2'>{product.name}</div>

                            <div className='text-xl text-center font-semibold'>{product.price} €</div>
                        </div>
                    </div>
                </Link>
            )}
        </section>
    );
}
export default Catalog;



