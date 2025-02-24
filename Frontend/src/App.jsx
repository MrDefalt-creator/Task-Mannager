import './App.css'
import checkAuth from './hooks/checkAuth.js';
import LoginPage from "./pages/LoginPage.jsx";
import {BrowserRouter, Routes, Route} from 'react-router-dom'
function App() {
  checkAuth();

  return (
    <main className='w-screen h-screen bg-white'>
      <BrowserRouter>
      <Routes>
        <Route path='login' element={<LoginPage/>}/>
      </Routes>
      </BrowserRouter>
      
    </main>
  )
}

export default App
