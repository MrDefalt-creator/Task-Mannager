import './App.css'
import LoginPage from "./pages/LoginPage.jsx";
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import RegistrationPage from "./pages/RegistrationPage.jsx";
import DashboardPage from "./pages/DashboarPage.jsx";

function App() {


    return (
        <main className='w-screen h-screen bg-white'>
            <BrowserRouter>
                <Routes>
                    <Route path='*' element={<LoginPage/>} />
                    <Route path='register' element={<RegistrationPage />} />
                    <Route path='dashboard/*' element={<DashboardPage />} />
                </Routes>
            </BrowserRouter>
        </main>
    );
}

export default App;
