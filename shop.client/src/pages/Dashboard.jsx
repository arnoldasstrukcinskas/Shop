import React, { useState, useEffect } from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';


function Dashboard({ manageCart }) {
    const [products, setProducts] = useState([]);
    const [page, setPage] = useState(1);
    const [hasMore, setHasMore] = useState(true);
    const [loading, setLoading] = useState(false);

    const manageProducts = async () => {
        if (loading) return;
        setLoading(true);

        try {
            const response = await fetch(`/Product/products?page=${page}&pageSize=20`);
            if (!response.ok) {
                alert("Failed to get products");
                return;
            }

            const data = await response.json();
            setProducts((prev) => prev.concat(data.data));
            if (page >= data.totalPages) {
                setHasMore(false);
            }
        } catch {
            setLoading(false);
            alert("Something went wrong");
        }
        setLoading(false);
    }

     // Runs fetchProduct upon page change.
    useEffect(() => {
        manageProducts();
    }, [page]);

    // Code for scrolling
    useEffect(() => {
        const handleScroll = () => {
            if (!hasMore || loading) return;

            if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 50) {
                setPage((prev) => prev + 1);
            }
        };

        window.addEventListener("scroll", handleScroll);
        return () => window.removeEventListener("scroll", handleScroll);
    }, [hasMore, loading]);

    return (
        <div className="dashboard-page">
            <h1>Dashboard</h1>
            <div style={{ gridTemplateColumns: '1fr 1fr' }} className="d-grid gap-2 row-gap-3">
            {products.map((p, index) => (
                <Card key={`${p.id}-${index}`} sx={{ minWidth: 275, mb: 2 }}>
                    <CardMedia
                        sx={{ height: 140 }}
                        image='../src/assets/react.svg'
                        title={p.image}
                    />
                    <CardContent>
                        <Typography variant="h5">{p.name}</Typography>
                        <Typography sx={{ color: 'text.secondary', mb: 1.5 }}>{p.price}</Typography>
                        <Typography variant="body2">{p.description}</Typography>
                    </CardContent>
                    <CardActions>
                        <Button variant="contained" onClick={() => manageCart(p)} color="success" size="small">Add To Cart</Button>
                    </CardActions>
                </Card>
            ))}
            </div>

            {loading && <p>Loading...</p>}
            {!hasMore && <p>No more products</p>}
        </div>
    );
}

export default Dashboard;