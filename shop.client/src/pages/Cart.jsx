import React, { useState } from "react";

function Cart({ totalItems, totalPrice }) {

    return (
        <div>
            <ShoppingCartIcon color="primary" />
            <span className="fw-bold">5</span> 
        </div>
    );
};

export default Cart;