import Header from "../components/common/Header.jsx";
import TaskList from "../components/dashboard_page/TaskList.jsx";
import TaskInfo from "../components/dashboard_page/TaskInfo.jsx";

export default function DashboardPage() {
    return (
        <main className="h-screen flex flex-col bg-gray-100">
            <Header />
            <div className="grid grid-cols-[0.8fr_2fr] gap-3 flex-1 pt-2 pb-2 overflow-hidden">
                <TaskList className="h-full" />
                <TaskInfo className="h-full" />
            </div>
        </main>
    );
}
