import {useState} from "react";
import {useSelector} from "react-redux";


export default function Header() {
    const [hidden, setHidden] = useState(true);
    const [hovered, setHovered] = useState(false);
    const {userId, user, email} = useSelector((state) => state.user);
    return (
        <header className='block w-full h-[5rem] bg-violet-600'>
            <div className='flex justify-around h-full items-center px-6'>
                <h2 className='text-white font-sans text-xl font-bold'>TASK-MANAGER</h2>
                <div className='relative'>
                    <img src='/vite.svg' alt='user' className='w-10 h-10 cursor-pointer' onMouseEnter={() => setHidden(false)} onMouseLeave={() => !hovered && setHidden(true)} />
                    {!hidden && (
                        <div onMouseEnter={() => setHovered(true)} onMouseLeave={() => {setHovered(false); setHidden(true)}} className='absolute top-[2.5rem] left-[-1rem] w-40 bg-white shadow-md rounded-md p-2 text-sm text-slate-600'>
                            <p className='truncate'>{userId}</p>
                            <p className='truncate'>{user}</p>
                            <p className='truncate'>{email}</p>
                        </div>
                    )}
                </div>
            </div>
        </header>
    )
}