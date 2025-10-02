import React, { useState } from 'react';
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
    const [totalItems, setTotalItems] = useState(0);
    const [totalPrice, setTotalPrice] = useState(0);

    const manageCart = async (product) => {
        setTotalItems(prevTotalItems => prevTotalItems + 1);
        setTotalPrice(prevPrice => prevPrice + Number(product.price));

        const currentCart = JSON.parse(localStorage.getItem("cart")) || [];
        currentCart.push(product.id);
        localStorage.setItem("cart", JSON.stringify(currentCart));
    }

    return (
        <Router>
            <Routes>
                <Route path="/register" element={<Register/> }/>
                <Route path="/login" element={<Login />} />
                <Route element={<Header totalItems={totalItems} totalPrice={totalPrice} />}>
                    <Route
                        path="/dashboard"
                        element={
                            <PrivateRoute>
                                <Dashboard manageCart={manageCart} />
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