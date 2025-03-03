export default function TaskInfo(){
    return(
        <section className='block w-full h-full'>
            <div className='flex justify-center mt-4 items-center'>
                <h3 className='font-sans text-xl font-semibold'>Информация о задаче</h3>
            </div>
            <div className='flex justify-around mt-4'>
                <div/>
                <p className='font-sans font-light text-base text-slate-600'>ID:</p>
            </div>
            <div className='px-7'>
               <h2 className='font-sans font-medium text-3xl'>TITLE</h2>
            </div>
            <div className='flex justify-around mt-6 px-7 items-center'>
                <p className='font-sans text-xl font-medium'>Создана в: </p>
                <p className='font-sans text-xl font-medium'>Необходимо завершить: </p>
            </div>
        </section>
    )
}