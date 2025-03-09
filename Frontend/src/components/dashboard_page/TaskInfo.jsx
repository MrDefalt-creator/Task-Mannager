import {useDispatch, useSelector} from "react-redux";
import { format } from "date-fns";
import {useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";
import {deleteTask, updateTask} from "../../store/taskSlice.js";

export default function TaskInfo() {
    const { taskId, title, description, createdAt, mustFinish } = useSelector((state) => state.task);
    const [editableDescr,setEditableDescr] = useState();
    const [editableMustFinish, setEditableMustFinish] = useState();
    const [editableTitle, setEditableTitle] = useState();
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [redacting, setRedacting] = useState(false);
    console.log(typeof(editableMustFinish))
    useEffect(() => {
        if (description) {
            setEditableDescr(description);
        }
        if (mustFinish) {
            setEditableMustFinish(mustFinish);
        }
        if (title) {
            setEditableTitle(title);
        }
    }, [description, mustFinish, title]);

    const submitRedacting = (e) => {
        if(editableMustFinish){
            dispatch(updateTask({id: taskId, title:editableTitle, description:editableDescr,
                mustFinishAt:editableMustFinish, navigate}));
            setRedacting(false);
        } else {
            alert('Выберите корректную дату завершения');
            e.preventDefault();
        }


    }

    const submitDelete = (e) =>{
        const result = confirm("Вы уверены что хотите удалить эту задачу?")
        if (result) {
            dispatch(deleteTask({id:taskId, navigate}));
        } else {
            e.preventDefault();
        }


    }
    return (
        <section className="block w-[99%] h-full p-3 bg-white rounded-lg shadow-lg">
            <div className="flex flex-col items-center">
                <h3 className="font-sans text-xl font-bold text-violet-500 mt-4">
                    Информация о задаче
                </h3>
                <p className="font-sans font-light text-base text-slate-600 mt-2">
                    ID: {taskId}
                </p>
                {redacting ? (
                    <input className="font-sans font-medium text-3xl mt-5
                    text-slate-600 border-2 border-slate-400 rounded-xl focus:outline-none focus:border-violet-500"
                    value={editableTitle}
                    onChange={(e) => setEditableTitle(e.target.value)}
                    />
                ) : (
                    <h2 className="font-sans font-medium text-3xl mt-5">
                        {title}
                    </h2>
                )}

                <div className="flex justify-around w-full max-w-lg mt-6 px-4">
                    <div className="flex flex-col items-center">
                        <span className="font-sans text-xl font-medium">Создана</span>
                        <span className="font-sans text-lg text-slate-600">
              {format(new Date(createdAt), "dd.MM.yyyy HH:mm")}
            </span>
                    </div>
                    {redacting ? (
                        <input
                            type="date"
                            value={editableMustFinish}
                            className="font-sans text-lg text-slate-600 border-[1px] focus:outline-none border-slate-400 rounded-xl focus:border-violet-500"
                            onChange={(e) => setEditableMustFinish(e.target.value)}
                        />
                    ): (
                        <div className="flex flex-col items-center">
                            <span className="font-sans text-xl font-medium">Завершить</span>
                            <span className="font-sans text-lg text-slate-600">
                {format(new Date(mustFinish), "dd.MM.yyyy")}
                        </span>
                        </div>
                    )}
                </div>
            </div>
            <div className="flex flex-col items-center w-full mt-8">
                <textarea
                    className="font-sans font-medium text-base w-[80%] border-[1px] border-slate-400 focus:outline-none h-[618px] resize-none p-3 rounded-lg focus:border-violet-500"
                    disabled={!redacting}
                    placeholder="Описание задачи"
                    value={editableDescr}
                    onChange={(e) => setEditableDescr(e.target.value)}
                />
                <div className="flex flex-row justify-center gap-4 mt-4">
                    <button
                        className="bg-red-600 px-6 py-3 font-sans font-medium text-base rounded-lg"
                        onClick={submitDelete}>
                        Удалить
                    </button>
                    {
                        redacting ? (
                            <div>
                                <button
                                    className="bg-red-400 px-6 py-3 font-sans font-medium text-base rounded-lg mr-4"
                                    onClick={()=> setRedacting(false)}
                                >
                                    Отменить изменение
                                </button>
                                <button
                                    className="bg-green-400 px-6 py-3 font-sans font-medium text-base rounded-lg"
                                    onClick={submitRedacting}
                                >
                                    Сохранить изменения
                                </button>
                            </div>

                        ) : (
                            <button
                                className="bg-orange-400 px-6 py-3 font-sans font-medium text-base rounded-lg"
                                onClick={()=> setRedacting(true)}
                            >
                                Редактировать задачу
                            </button>
                        )
                    }

                </div>
            </div>

        </section>
    );
}
