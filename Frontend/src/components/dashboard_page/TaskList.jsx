import ElementOfList from "./ElementOfList.jsx";
import { useEffect, useState } from "react";
import TaskEndpoints from "../../endpoints/TaskEndpoints.js";
import {useDispatch} from "react-redux";
import {getTask} from "../../store/taskSlice.js";

export default function TaskList() {
    const [fetchedTasks, setFetchedTasks] = useState([]);
    const dispatch = useDispatch();
    useEffect(() => {
        const getTasks = async () => {
            try {
                const taskList = (await TaskEndpoints.getTasks()).data;
                setFetchedTasks(taskList);
            } catch (e) {
                console.error(e);
                setFetchedTasks([]);
            }
        };

        getTasks();
    }, []);

    const [selectedTask, setSelectedTask] = useState(null);

    if (fetchedTasks === null) {
        return <div className='flex justify-center font-bold items-center font-sans'>Задачи загружаются...</div>;
    }

    return (
        <section className='block shadow-xl rounded-lg ml-2 bg-white'>
            <div className='flex items-center justify-center mt-4'>
                <h3 className='font-sans text-xl font-semibold text-violet-500'>Список Задач</h3>
            </div>
            <div className='flex flex-col items-center mt-4 gap-1'>
                {
                    fetchedTasks.length > 0 ? (
                        fetchedTasks.map((task) => (
                            <ElementOfList
                                key={task.id}
                                task={task}
                                isSelected={selectedTask === task.id}
                                onSelect={() => { setSelectedTask(task.id); dispatch(getTask({id: task.id})); }} />
                        ))
                    ) : (
                        <div className='flex justify-center items-center'>Нет задач для отображения</div>
                    )
                }
            </div>
        </section>
    );
}
