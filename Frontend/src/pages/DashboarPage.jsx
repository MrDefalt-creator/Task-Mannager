import Header from "../components/common/Header.jsx";
import TaskList from "../components/dashboard_page/TaskList.jsx";

export default function DashboardPage(){
    return(
        <main>
            <Header/>
            <main className='grid grid-cols-[0.8fr_2fr]'>
                <TaskList/>
            </main>
        </main>
    )
}