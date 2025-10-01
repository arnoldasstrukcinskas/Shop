import React from "react";
import { Link, Outlet } from 'react-router-dom';

function Header() {
    return (
        <div>
        <nav className="bg-light border navbar navbar-expand-lg navbar-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="/"><span className="text-primary">C</span><span className="text-danger">$</span><span className="text-warning">5</span><span className="text-success">0</span> <span className="text-danger">Finance</span></a>
                <button aria-controls="navbar" aria-expanded="false" aria-label="Toggle navigation" className="navbar-toggler" data-bs-target="#navbar" data-bs-toggle="collapse" type="button">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbar">
                    <ul className="navbar-nav me-auto mt-2">
                        <li className="nav-item"><Link className="nav-link" to="/quote">Quote</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/buy">Buy</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/sell">Sell</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/history">History</Link></li>
                    </ul>
                    <ul className="navbar-nav ms-auto mt-2">
                        <li className="nav-item"><Link className="nav-link" to="/change_pass">Change Password</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/logout">Log Out</Link></li>
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