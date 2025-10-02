import React from "react";
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import { Link, Outlet } from 'react-router-dom';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';

function Header({totalItems}) {
    const navigate = useNavigate();

    const logout = async () => {
        localStorage.removeItem("token");
        localStorage.removeItem("cart");

        navigate("/login");
    }

    const cartClick = async () => {
        navigate("/cart");
    }

    return (
        <div className="sticky-bottom">
        <nav className="bg-light border navbar navbar-expand-lg navbar-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="/"><span className="text-primary">S</span><span className="text-danger">H</span><span className="text-warning">O</span><span className="text-success">P</span> <span className="text-danger">API</span></a>
                <button aria-controls="navbar" aria-expanded="false" aria-label="Toggle navigation" className="navbar-toggler" data-bs-target="#navbar" data-bs-toggle="collapse" type="button">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbar">
                    <ul className="navbar-nav me-auto mt-2">
                        <li className="nav-item"><Link className="nav-link" to="/profile">Profile</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/dashboard">Dashboard</Link></li>
                        <li className="nav-item mx-1">
                                <Button onClick={cartClick}>
                                <ShoppingCartIcon color="primary" />
                                <span className="fw-bold">{totalItems}</span>
                            </Button>
                        </li>
                    </ul>
                    <ul className="navbar-nav ms-auto mt-2">
                            <li className="nav-item"><Button variant="outlined" color="error" onClick={logout}>Log Out</Button></li>
                    </ul>
                </div>
            </div>
            </nav>

            <div className="container mt-3">
                <Outlet />
            </div>
        </div>
    );
}

export default Header;