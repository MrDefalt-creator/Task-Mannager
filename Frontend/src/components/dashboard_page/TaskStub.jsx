import {useSelector} from "react-redux";
export default function TaskStub() {
    const {taskId} = useSelector((state) => state.task);
    return (
        <section className="block w-[99%] h-full p-3 bg-white rounded-lg shadow-lg">
            <div className='flex flex-col gap-2 items-center h-full justify-center'>
                <h1 className='font-sans font-bold text-xl text-slate-400'>Задача не выбрана</h1>
                <p className='font-sans font-medium text-base text-slate-400'>Если задач нет, создайте новую</p>
                <button className='w-[8rem] rounded-md bg-violet-600 hover:bg-violet-700 text-white font-sans py-1.5 mt-2'>Cоздать задачу</button>
            </div>
        </section>
    )
}