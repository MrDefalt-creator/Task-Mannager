export default function CreateTask() {
    return (
        <section className="block w-full mx-auto h-full p-5 bg-white rounded-lg shadow-lg">
            <div className='flex items-center justify-center'>
                <h3 className='font-sans text-xl font-semibold text-violet-500'>
                    Создание задачи
                </h3>
            </div>
            <div className='flex flex-col items-center gap-5 mt-8'>
                <div className='flex flex-col items-center'>
                    <h5 className='text-slate-500 text-xl font-sans font-medium'>Заголовок задачи</h5>
                    <input
                        type='text'
                        className='w-[18rem] px-5 py-2 border-[1px] rounded-lg focus:border-violet-500 focus:outline-none'/>
                </div>
                <div className='flex flex-col items-center'>
                    <h5 className='text-slate-500 text-xl font-sans font-medium'>Необходимо завершить</h5>
                    <input
                        type='date'
                        className='font-sans w-[18rem] px-5 py-2 border-[1px] rounded-lg focus:border-violet-500 focus:outline-none'/>
                </div>
                <div className='flex flex-col items-center'>
                    <h5 className='text-slate-500 text-xl font-sans font-medium'>Описание</h5>
                    <textarea
                        className='w-[18rem] resize-none px-5 py-2 border-[1px] rounded-lg focus:border-violet-500 focus:outline-none h-[10rem]'/>
                </div>
                <div className='flex items-center justify-center'>
                    <button
                        className='w-[8rem] px-5 py-2 rounded-lg bg-red-500 hover:bg-red-600 text-white font-medium mx-2'>
                        Отменить создание
                    </button>
                    <button
                        className='w-[8rem] px-5 py-2 rounded-lg bg-green-500 hover:bg-green-600 text-white font-medium mx-2'>
                        Создать задачу
                    </button>
                </div>
            </div>
        </section>
    );
}
