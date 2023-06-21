import React from 'react';
import { BrowserRouter, Routes, Route} from 'react-router-dom';

import Header from '../Components/Header';
import Footer from '../Components/Footer';
import Nav from '../Components/Nav';

import Catalog from '../Views/Catalog';
import Detail from '../Views/Detail';
import Home from '../Views/Home';

const RoutesWithNavigation = () => {
    return (
        <BrowserRouter className='h-screen'>
            <Header />
            <Nav />
            <main>
                <Routes>
                    <Route path='/catalog' element={<Catalog />} />
                    <Route path='/catalog/:id' element={<Detail />} />
                    <Route path='/' element={<Home />} />
                </Routes>
            </main>
            <Footer />
        </BrowserRouter>
    )
}
export default RoutesWithNavigation; 