import axios from 'axios';

export const GetProduct = () => {
    return axios.get(`${process.env.REACT_APP_BASE_URL}/catalog`);
};

export const GetProductById = (id) => {
    return axios.get(`${process.env.REACT_APP_BASE_URL}/catalog/${id}`);
};

export const GetProductByCategory = (category) => {
    return axios.get(`${process.env.REACT_APP_BASE_URL}/catalog/bycat/${category}`);
};

export const CreateProduct = (data) => {
    return axios.post(`${process.env.REACT_APP_BASE_URL}/catalog`, data);
};

export const UpdateProduct = () => {
    return axios.put(`${process.env.REACT_APP_BASE_URL}/catalog`);
};

export const DeleteProduct = (id) => {
    return axios.delete(`${process.env.REACT_APP_BASE_URL}/catalog/${id}`);
};