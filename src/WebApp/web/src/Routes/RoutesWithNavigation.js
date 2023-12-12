import React from 'react';
import { BrowserRouter, Routes, Route} from 'react-router-dom';

import Header from '../Components/Header';
import Footer from '../Components/Footer';
import Nav from '../Components/Nav';

import Catalog from '../Views/Catalog';
import Detail from '../Views/Detail';
import Home from '../Views/Home';
import User from '../Views/User';
import SigninPage from '../Views/SigninPage';
import LoginPage from '../Components/Login';
import Password from '../Components/Password';
import Product from '../Views/Product';
// import Slideshow from '../Components/Slideshow';

const RoutesWithNavigation = () => {
    return (
        <BrowserRouter>
            <Header />
            <Nav />
            <main>
                <Routes>
                    <Route path='/catalog' element={<Catalog />} />
                    <Route path='/catalog/:id' element={<Detail />} />
                    <Route path='/client' element={<User />} />
                    <Route path='/client' element={<LoginPage />} />
                    <Route path='/client' element={<Password />} />
                    {/* <Route path='/bio' element={<Slideshow />} /> */}
                    <Route path='/product' element={<Product />} />
                    <Route path='/client/signin' element={<SigninPage />} />
                    <Route path='/' element={<Home />} />
                </Routes>
            </main>
            <Footer />
        </BrowserRouter>
    )
}
export default RoutesWithNavigation; 