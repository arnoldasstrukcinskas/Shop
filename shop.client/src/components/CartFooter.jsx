import React from 'react';
import Button from '@mui/material/Button';

function CartFooter({ totalItems, totalPrice }) {

    return (
        <div className="sticky-bottom">
            <nav className="bg-light border navbar navbar-expand-lg navbar-light">
                <div className="container-fluid">
                    <div className="collapse navbar-collapse" id="navbar">
                        <ul className="navbar-nav me-auto mt-2">
                            <li className="nav-item">
                                <span>Items in Cart: </span>
                                <span>{totalItems}</span>
                            </li>
                        </ul>
                        <ul className="navbar-nav ms-auto mt-2">
                            <li className="nav-item mx-1">
                                <span><strong>Total: </strong></span>
                                <span><strong>{totalPrice}$</strong></span>
                            </li>
                            <li className="nav-item mx-1"><Button variant="outlined" color="success">Buy</Button></li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div className="container mt-3">
            </div>
        </div>
    );
}

export default CartFooter;