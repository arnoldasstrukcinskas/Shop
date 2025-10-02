import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import CartFooter from "../components/CartFooter";

function Cart({ totalItems, totalPrice, setTotalItems, setTotalPrice }) {
    const [productsCart, setProductsCart] = useState([]);
    const navigate = useNavigate();

    const getProduct = async (id) => {
        try {
            const response = await fetch(`/Product/product?id=${id}`)
            const data = await response.json();
            return data;
        }
        catch {
            console.error("No such product", id);
        }
    }

    const loadCart = async () => {
        const storedCartIds = JSON.parse(localStorage.getItem("cart")) || [];
        if (storedCartIds.length <= 0) {
            alert("Apologise, cart is empty");
            navigate('/dashboard');
            return;
        }

        const productsArray = [];

        for (const id of storedCartIds) {
            console.log(id);
            try {
                const product = await getProduct(id);
                if (product) {
                    productsArray.push(product);
                } else {
                    console.error("Cart: no such product");
                }
            } catch {
                console.error("Cart: Something wrong with id", id);
            }
        }

        setProductsCart(productsArray);
    };


    const removeItem = async (p) => {
        let productsInCart = [];
        productsInCart = JSON.parse(localStorage.getItem("cart")) || [];

        for (let i = 0; i < productsInCart.length; i++) {
            if (productsInCart[i] === p.id) {
                console.log("removing");
                console.log(productsInCart[i]);
                productsInCart.splice(i, 1);
                break;
            }
        }

        setTotalPrice(prevTotalPrice => prevTotalPrice - Number(p.price));
        setTotalItems(productsInCart.length);
        localStorage.setItem("cart", JSON.stringify(productsInCart));
        alert(`Item: ${p.name}, removed`)
        await loadCart();
    } 

    useEffect(() => {
        loadCart();
    }, []);




    return (
        <div className="dashboard-page">
            <h1>Cart</h1>

            {productsCart.map((p, index) => (
                <Card key={`${p.id}-${index}`} sx={{ minWidth: 275, mb: 2 }}>
                    <CardMedia
                        sx={{ height: 140 }}
                        image='../src/assets/react.svg'
                        title={p.image}
                    />
                    <CardContent>
                        <Typography variant="h5">{p.name}</Typography>
                        <Typography sx={{ color: 'text.secondary', mb: 1.5 }}>{p.price}</Typography>
                        <Typography variant="body2">Quantity</Typography>
                    </CardContent>
                    <CardActions>
                        <Button onClick={() => removeItem(p)} color="error" size="small">Remove</Button>
                    </CardActions>
                </Card>
            ))}
            <CartFooter totalItems={totalItems} totalPrice={totalPrice}/>
        </div>
    );
};

export default Cart;