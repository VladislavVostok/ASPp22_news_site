import React from 'react'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Login from "./components/Login";
import Register from './components/Register';
// import ProtectedRoute from './components/ProtectedRoute';

// const Profile: React.FC = () => <h2>Профиль пользователя (только для зарегистрированных)</h2>;

const App: React.FC = () => (
   <BrowserRouter>
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/" element={<h2>Главная страница</h2>} />

      {/* <ProtectedRoute>
        <Profile />
      </ProtectedRoute> */}
    </Routes>
  </BrowserRouter>
);

export default App;
