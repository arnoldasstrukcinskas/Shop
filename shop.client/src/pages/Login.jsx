import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const ReactComponent = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const login = async () => {
        try {
            const response = await fetch("/login", {
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
            navigate("/dashboard");
        } catch {
            alert("Something went wrong");
        }
    };

  return (
      <div>
          <h2>Login</h2>
          <input
              placeholder="username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
          />
          <input
              placeholder="password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
          />
          <button onClick={login}>Login</button>
      </div>
  );
};

export default ReactComponent;