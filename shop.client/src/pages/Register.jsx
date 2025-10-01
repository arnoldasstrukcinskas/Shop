import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import TextField from "@mui/material/TextField";

function Register() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [age, setAge] = useState("");

    const navigate = useNavigate();

        const register = async () => {
            try {
                const response = await fetch("/Authentication/register", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({ username, name, age, email, password }),
                });

                if (!response.ok) {
                    alert("Failed to register!");
                    return;
                }

                navigate("/login");
            } catch {
                alert("Something went wrong");
            }
        };

        return (
            <div className="container py-5 text-center">
                <h2 className="mb-3">Register</h2>

                <div className="mb-3">
                    <TextField
                        placeholder="Username"
                        autoComplete="off"
                        className="form-control mx-auto w-auto"
                        type="text"
                        autoFocus
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <TextField
                        placeholder="Name"
                        autoComplete="off"
                        className="form-control mx-auto w-auto"
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <TextField
                        placeholder="Age"
                        autoComplete="off"
                        className="form-control mx-auto w-auto"
                        type="number"
                        value={age}
                        onChange={(e) => setAge(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <TextField
                        placeholder="email"
                        autoComplete="off"
                        type="email"
                        className="form-control mx-auto w-auto"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className="mb-3">
                    <TextField
                        placeholder="password"
                        autoComplete="off"
                        className="form-control mx-auto w-auto"
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <Button variant="contained" onClick={register}>Register</Button>
                </div>
            </div>
        );
}



export default Register;