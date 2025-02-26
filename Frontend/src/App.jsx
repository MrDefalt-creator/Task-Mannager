import './App.css'
import checkAuth from './hooks/checkAuth.js';
import LoginPage from "./pages/LoginPage.jsx";
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import RegistrationPage from "./pages/RegistrationPage.jsx";
function App() {


  return (
    <main className='w-screen h-screen bg-white'>
      <BrowserRouter>
      <Routes>
        <Route path='login' element={<LoginPage/>}/>
        <Route path='register' element={<RegistrationPage/>}/>
      </Routes>
      </BrowserRouter>
      
    </main>
  )
}

export default App
