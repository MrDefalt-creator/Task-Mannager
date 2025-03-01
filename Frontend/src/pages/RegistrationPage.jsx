import AuthContainer from "../components/auth_page/AuthContainer.jsx";
import {useDispatch, useSelector} from "react-redux";
import {useState} from "react";
import {NavLink} from "react-router-dom";
import {registerUser} from "../store/userSlice.js";

export default function RegistrationPage() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    const dispatch = useDispatch();
    const {loading, error} = useSelector((state) => state.user);

    const handleLogin = async (e) =>{
        e.preventDefault();
        if(username && email && password){
            dispatch(registerUser({username, email, password}));
        }

    }

    return (
        <section>
            <AuthContainer>
                <form onSubmit={handleLogin} className="flex flex-col gap-2">
                    <input placeholder="Имя" type="text" className="input-auth" value={username} onChange={(e) => setUsername(e.target.value)} />
                    <input placeholder="Email" type="email" className="input-auth" value={email} onChange={(e) => setEmail(e.target.value)} />
                    <input placeholder="Пароль" type="password" className="input-auth" value={password} onChange={(e) => setPassword(e.target.value)} />
                    <div className='flex justify-between'>
                        <p className='font-sans text-center text-xs'>Уже пользователь?</p>
                        <NavLink to='/login' className='font-sans text-center text-xs text-violet-600'>Войти</NavLink>
                    </div>
                    <button type='submit' disabled={loading} className={'w-full rounded-md bg-violet-600 hover:bg-violet-700 text-white font-sans py-1.5'}>
                        {loading ? "Регистрация..." : "Зарегистрироваться"}
                    </button>
                    {error && <p className="text-red-500 text-sm">{error}</p>}
                </form>
            </AuthContainer>
        </section>
    )
}