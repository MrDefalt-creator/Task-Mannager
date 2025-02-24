import { useEffect } from "react";
import $api from "../http";
import {useDispatch} from 'react-redux'
import {logout} from '../store/userSlice'
export default function(){
    const dispatch = useDispatch();
    useEffect(() => {
        const checkValidation = async () => {
            try{
               await $api.get('/check-validation')
            } catch(e) {
                if(e.response?.status === 401){
                    dispatch(logout());
                    window.location.reload();
                }
            }

            
        };
        checkValidation();

        const intervalId = setInterval(checkValidation,3600000);
        
        return() => clearInterval(intervalId)

    }, [dispatch]);
}