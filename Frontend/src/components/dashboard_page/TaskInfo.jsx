import { useSelector } from "react-redux";
import { format } from "date-fns";

export default function TaskInfo() {
    const { taskId, title, description, createdAt, mustFinish } = useSelector((state) => state.task);
    return (
        <section className="block w-[99%] h-full p-3 bg-white rounded-lg shadow-lg">
            <div className="flex flex-col items-center">
                <h3 className="font-sans text-xl font-bold text-violet-500 mt-4">
                    Информация о задаче
                </h3>
                <p className="font-sans font-light text-base text-slate-600 mt-2">
                    ID: {taskId}
                </p>
                <h2 className="font-sans font-medium text-3xl mt-5">
                    {title}
                </h2>
                <div className="flex justify-around w-full max-w-lg mt-6 px-4">
                    <div className="flex flex-col items-center">
                        <span className="font-sans text-xl font-medium">Создана</span>
                        <span className="font-sans text-lg text-slate-600">
              {format(new Date(createdAt), "dd.MM.yyyy HH:mm")}
            </span>
                    </div>
                    <div className="flex flex-col items-center">
                        <span className="font-sans text-xl font-medium">Завершить</span>
                        <span className="font-sans text-lg text-slate-600">
              {format(new Date(mustFinish), "dd.MM.yyyy")}
            </span>
                    </div>
                </div>
            </div>
            <div className="flex justify-center h-full w-full mt-8">
        <textarea
            className="font-sans font-medium text-base w-[80%] border-2 border-slate-400 focus:outline-none h-[618px] resize-none"
            defaultValue={description}
        />
            </div>
        </section>
    );
}
