import AuthContainer from "../components/auth_page/AuthContainer.jsx";
import {useDispatch, useSelector} from "react-redux";
import {loginUser} from "../store/userSlice.js";
import {useEffect, useState} from "react";
import {NavLink, useNavigate} from "react-router-dom";
export default function LoginPage() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberMe, setRememberMe] = useState(false);
    const dispatch = useDispatch();
    const {loading, error, userId} = useSelector((state) => state.user);
    const navigate = useNavigate();

    useEffect(() => {
        if(userId){
            navigate(`/dashboard/`);
        }
    })

    const handleLogin = async (e) =>{
        e.preventDefault();
        if(email && password){
            try{
                await dispatch(loginUser({email, password, rememberMe}));
                navigate("/dashboard");
            } catch(e){
                e.preventDefault()
            }

        }

    }

    return (
        <section>
            <AuthContainer>
                <form onSubmit={handleLogin} className="flex flex-col gap-2">
                    <input placeholder="Email" type="email" className="input-auth" value={email} onChange={(e) => setEmail(e.target.value)} />
                    <input placeholder="Пароль" type="password" className="input-auth" value={password} onChange={(e) => setPassword(e.target.value)} />
                    <div className='flex place-content-around'>
                        <input type='checkbox' className='w-4' style={{accentColor: "#7e22ce"}} value={rememberMe} onChange={()=>setRememberMe(!rememberMe)} />
                        <p className='font-sans text-center text-xs'>Запомнить меня на 30 дней</p>
                    </div>
                    <div className='flex justify-between'>
                        <p className='font-sans text-center text-xs'>Не пользователь?</p>
                        <NavLink to='/register' className='font-sans text-center text-xs text-violet-600'>Зарегистрироваться</NavLink>
                    </div>
                    <button type='submit' disabled={loading} className={'w-full rounded-md bg-violet-600 hover:bg-violet-700 text-white font-sans py-1.5'}>
                        {loading ? "Вход..." : "Войти"}
                    </button>
                    {error && <p className="text-red-500 text-sm">{error}</p>}
                </form>
            </AuthContainer>
        </section>
    )
}