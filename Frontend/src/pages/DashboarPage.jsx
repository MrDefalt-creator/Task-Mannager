import Header from "../components/common/Header.jsx";
import TaskList from "../components/dashboard_page/TaskList.jsx";
import TaskInfo from "../components/dashboard_page/TaskInfo.jsx";
import {Routes, Route} from "react-router-dom";
import TaskStub from "../components/dashboard_page/TaskStub.jsx";
import CreateTask from "../components/dashboard_page/CreateTask.jsx";
import useCheckAuth from "../hooks/checkAuth.js";

export default function DashboardPage() {
    useCheckAuth();
    return (
        <main className="h-screen flex flex-col bg-gray-100">
            <Header />
            <div className="grid grid-cols-[0.8fr_2fr] gap-3 flex-1 pt-2 pb-2 overflow-hidden">
                <TaskList className="h-full" />
                <Routes>
                    <Route path="taskinfo" element={<TaskInfo className="h-full" />}/>
                    <Route path='createtask' element={<CreateTask className="h-full" />}/>
                    <Route path='/' element={<TaskStub className="h-full"/>}/>
                </Routes>

            </div>
        </main>
    );
}
