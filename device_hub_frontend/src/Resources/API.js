import axios from 'axios';
import jwtDecode from 'jwt-decode';

const JWT = 'jwtToken';
const JWTrefresh = 'jwtTokenRefresh';

const instance = axios.create({
  baseURL: 'http://localhost:8000/',
});

instance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem(JWT);
    if (token != null) {
      // eslint-disable-next-line no-param-reassign
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (err) => Promise.reject(err),
);

export const setToken = (token) => {
  localStorage.setItem(JWT, token);
  return jwtDecode(token);
};

export const setRefreshToken = (refreshToken) => {
  localStorage.setItem(JWTrefresh, refreshToken);
  return jwtDecode(refreshToken);
};

export const removeToken = () => {
  localStorage.removeItem(JWT);
};

export const getDecodedToken = () => jwtDecode(localStorage.getItem(JWT));

export const isTokenValid = () => (
  localStorage.jwtToken ? jwtDecode(localStorage.getItem(JWT)).exp > Date.now() / 100000 : false
);

export const getAuthHeader = () => ({ Authorization: `Bearer ${localStorage.getItem(JWT)}` });

export default instance;
