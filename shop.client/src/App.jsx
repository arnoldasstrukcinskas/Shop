import React, { useState } from 'react';
import Login from './pages/Login';
import Register from './pages/Register';
import Dashboard from './pages/Dashboard';
import Header from './components/Header'
import Cart from './pages/Cart';
import Profile from './pages/Profile'
import './App.css';
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";


function PrivateRoute({ children }) {
    const token = localStorage.getItem("token");
    return token ? children : <Navigate to="/login" />

}

function App() {
    const [totalItems, setTotalItems] = useState(0);
    const [totalPrice, setTotalPrice] = useState(0);

    const manageCart = (product) => {
        const currentCart = JSON.parse(localStorage.getItem("cart")) || [];
        const existingItem = currentCart.find(item => item.id === product.id);

        if (existingItem) {
            existingItem.quantity += 1;
        } else {
            currentCart.push({ id: product.id, quantity: 1 });
        }

        localStorage.setItem("cart", JSON.stringify(currentCart));

        setTotalPrice(prevPrice => prevPrice + Number(product.price));
        setTotalItems(prevTotalItems => prevTotalItems + 1);
    }

    return (
        <Router>
            <Routes>
                <Route path="/register" element={<Register/> }/>
                <Route path="/login" element={<Login />} />
                <Route element={<Header totalItems={totalItems} setTotalItems={setTotalItems} setTotalPrice={setTotalPrice} />}>
                    <Route
                        path="/dashboard"
                        element={
                            <PrivateRoute>
                                <Dashboard manageCart={manageCart} />
                            </PrivateRoute>
                        }
                    />
                    <Route
                        path="/profile"
                        element={
                            <PrivateRoute>
                                <Profile />
                            </PrivateRoute>
                        }
                    />
                    <Route
                        path="/cart"
                        element={
                            <PrivateRoute>
                                <Cart
                                    totalItems={totalItems}
                                    totalPrice={totalPrice}
                                    setTotalItems={setTotalItems}
                                    setTotalPrice={setTotalPrice}
                                />
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