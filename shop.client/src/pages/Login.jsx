import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import Register from './Register';
import TextField from "@mui/material/TextField";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const registerClick = () => {
        navigate("/register");
    }

    const login = async () => {
        try {
            const response = await fetch("/Authentication/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) {
                alert("Failed to login");
                return;
            }

            const data = await response.json();
            localStorage.setItem("token", data.token);
            localStorage.setItem("cart", "[]")
            navigate("/dashboard");
        } catch {
            alert("Something went wrong");
        }
    };

    return (
        <div className="container py-5 text-center">
            <h2>Login</h2>
            <div className="mb-3">
                <TextField
                    placeholder="username"
                    autoFocus
                    type="text"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    />
            </div>
            <div className="mb-3">
                 <TextField
                          placeholder="password"
                          type="password"
                          value={password}
                          onChange={(e) => setPassword(e.target.value)}
                />
            </div>
            <div className="mb-3">
                <Button variant="contained" onClick={login}>Login</Button>
            </div>
            <div className="mb-3">
                <Button variant="contained" onClick={registerClick}>Register</Button>
            </div>
        </div>
            
  );
};

export default Login;