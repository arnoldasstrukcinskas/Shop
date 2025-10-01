import React from 'react';
import Login from './pages/Login';
import Register from './pages/Register';
import Dashboard from './pages/Dashboard';
import Header from './components/Header'
import './App.css';
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";


function PrivateRoute({ children }) {
    const token = localStorage.getItem("token");
    return token ? children : <Navigate to="/login" />

}

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/register" element={<Register/> }/>
                <Route path="/login" element={<Login />} />
                <Route element={<Header />}>
                    <Route
                        path="/dashboard"
                        element={
                            <PrivateRoute>
                                <Dashboard />
                            </PrivateRoute>
                        }
                    />
                </Route>
                <Route path="*" element={<Navigate to="/login" />} />
            </Routes>
        </Router>
    );
}

export default App;