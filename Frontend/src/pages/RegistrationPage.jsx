import AuthContainer from "../components/auth_page/AuthContainer.jsx";
import {useDispatch, useSelector} from "react-redux";
import {loginUser} from "../store/userSlice.js";
import {useState} from "react";
import UserEndpoints from "../endpoints/UserEndpoints.js";
import {NavLink} from "react-router-dom";

export default function RegistrationPage() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    const [loading, setLoading] = useState(false)
    const dispatch = useDispatch();
    const {error} = useSelector((state) => state.user);

    const handleLogin = async (e) =>{
        e.preventDefault();
        if(username && email && password){
            setLoading(true);
            await UserEndpoints.register(username,email,password);
            dispatch(loginUser({email, password, rememberMe: true}));
            setLoading(false);
        } else {
            setLoading(false);
        }

    }

    return (
        <section>
            <AuthContainer>
                <form onSubmit={handleLogin} className="flex flex-col gap-2">
                    <input placeholder="Имя" type="text" className="input-auth" value={username} onChange={(e) => setUsername(e.target.value)} />
                    <input placeholder="Email" type="email" className="input-auth" value={email} onChange={(e) => setEmail(e.target.value)} />
                    <input placeholder="Пароль" type="password" className="input-auth" value={password} onChange={(e) => setPassword(e.target.value)} />
                    <div className='flex place-content-around'>
                        <p className='font-sans text-center text-sm'>Уже зарегистрированы?</p>
                        <NavLink className='font-sans text-center text-sm text-violet-600'>Войти</NavLink>
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