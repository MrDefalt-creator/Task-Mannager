import AuthContainer from "../components/auth_page/AuthContainer.jsx";

export default function LoginPage() {
    return (
        <section>
            <AuthContainer>
                <input placeholder="Email" type="email" className="input-auth"/>
                <input placeholder="Пароль" type="password" className="input-auth"/>
                <div className='flex place-content-around'>
                    <input type='checkbox' className='w-4' style={{accentColor: "#7e22ce"}}/>
                    <p className='font-sans text-center text-sm'>Запомнить меня на 30 дней</p>
                </div>
                <button className='w-full rounded-md bg-violet-600 hover:bg-violet-700 text-white font-sans py-1.5'>Войти</button>
            </AuthContainer>
        </section>
    )
}