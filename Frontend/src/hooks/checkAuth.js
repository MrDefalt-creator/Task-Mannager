import { useEffect } from "react";
import $api from "../http";
import { useDispatch } from 'react-redux';
import { useNavigate } from "react-router-dom";
import { logout } from '../store/userSlice';

export default function useCheckAuth() {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    useEffect(() => {
        const checkValidation = async () => {
            try {
                await $api.get('/check-validation');
            } catch (e) {
                if (e.response?.status === 401) {
                    dispatch(logout());
                    navigate('/login');
                }
            }
        };

        checkValidation();
    }, [dispatch, navigate]);
}