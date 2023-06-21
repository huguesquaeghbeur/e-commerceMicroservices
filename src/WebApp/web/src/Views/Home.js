import React from 'react';
import iphon from '../Assets/Images/iphon.jpg';
import lenovo from '../Assets/Images/lenovo.jpg';
import samsung from '../Assets/Images/samsung.webp';

const Home = () => {
    return (
        <section>
            <div id='animation-carousel' className='relative w-full' data-carousel='slide'>
                <div className='relative h-96 overflow-hidden h-screen'>
                    <div className='hidden duration-100 ease-in-out' data-carousel-item>
                        <img src={iphon} className='absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 grayscale hover:grayscale-0'alt="Une forêt" />
                    </div>
                    <div className='hidden duration-100 ease-in-out' data-carousel-item='active'>
                        <img src={lenovo} className='absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 grayscale hover:grayscale-0'alt="Une plage" />
                    </div>
                    <div className='hidden duration-100 ease-in-out' data-carousel-item>
                        <img src={samsung} className='absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 grayscale hover:grayscale-0'alt="Une montagne" />
                    </div>
                </div>
            </div>
        </section>
    )
}
export default Home