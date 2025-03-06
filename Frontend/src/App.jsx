import './App.css'
import checkAuth from './hooks/checkAuth.js';
import LoginPage from "./pages/LoginPage.jsx";
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import RegistrationPage from "./pages/RegistrationPage.jsx";
import DashboardPage from "./pages/DashboarPage.jsx";
function App() {
    checkAuth();

  return (
    <main className='w-screen h-screen bg-white'>
      <BrowserRouter>
      <Routes>
        <Route path='login' element={<LoginPage/>}/>
        <Route path='register' element={<RegistrationPage/>}/>
          <Route path='dashboard/*' element={<DashboardPage/>}/>
      </Routes>
      </BrowserRouter>
      
    </main>
  )
}

export default App
