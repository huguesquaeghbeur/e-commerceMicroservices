import axios from 'axios';

export const Login = (data) => {
    return axios.post(`${process.env.REACT_APP_BASE_URL}/client/login`, data);   
};

export const Signin = (data) => {
    return axios.post(`${process.env.REACT_APP_BASE_URL}/client/signin`, data);
}