import AuthPlaceholder from "./AuthPlaceholder.jsx";


export default function AuthContainer({ children }) {

    return (
        <div className="mx-auto max-w-[720px] flex flex-col">
            <AuthPlaceholder/>
            <div className="justify-center flex">
                <img src='/vite.svg' alt='site-logo' className='w-[10rem] h-[10rem]'/>
            </div>
            <h4 className='text-center font-sans text-2xl font-medium mt-4 mb-4'>
                Воспользуйтесь TManager <br/> уже сейчас!
            </h4>
            <p className='text-center text-slate-600'>
                Введите ваши данные <br/> для работы в TManager
            </p>
            <div className="mt-[49px] mx-auto grid grid-cols-1 gap-6">
                {children}
            </div>
        </div>
    )
}
