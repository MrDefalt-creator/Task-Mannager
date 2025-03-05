import {useSelector} from "react-redux";

export default function TaskInfo(){
    const {taskId, title, description, createdAt,mustFinish} = useSelector((state) => state.task);
    return(
        <section className='block w-[99%] h-full p-3 bg-white rounded-lg shadow-lg'>
            <div className='flex justify-center mt-4 items-center'>
                <h3 className='font-sans text-xl font-semibold text-violet-500'>Информация о задаче</h3>
            </div>
            <div className='flex justify-around mt-4'>
                <div/>
                <p className='font-sans font-light text-base text-slate-600'>ID: {taskId}</p>
            </div>
            <div className='flex justify-center mt-5'>
               <h2 className='font-sans font-medium text-3xl'>{title}</h2>
            </div>
            <div className='flex justify-around mt-6 px-7 items-center'>
                <p className='font-sans text-xl font-medium'>Создана в: {createdAt}</p>
                <p className='font-sans text-xl font-medium'>Необходимо завершить: {mustFinish}</p>
            </div>
            <div className='flex justify-center h-full w-full mt-8'>
                <textarea
                    className='font-sans font-medium text-base w-[80%] border-2 border-slate-400 focus:outline-none h-[618px] resize-none'

                >{description}</textarea>
            </div>
        </section>
    )
}