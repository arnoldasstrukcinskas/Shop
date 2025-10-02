import React from 'react';
import { Card, CardContent, Typography, Avatar, Box } from "@mui/material";

function Profile() {
    const data = JSON.parse(localStorage.getItem("user")) || {};
    const user = data.user || {};

    return (
        <Box
            sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                bgcolor: "#f5f5f5",
                p: 2,
            }}
        >
            <Card sx={{ maxWidth: 400, width: "100%", p: 2, boxShadow: 3, borderRadius: 3 }}>
                <Box sx={{ display: "flex", justifyContent: "center", mb: 2 }}>
                    <Avatar sx={{ width: 80, height: 80, bgcolor: "#1976d2" }}>
                        {user.username ? user.username[0].toUpperCase() : "U"}
                    </Avatar>
                </Box>
                <CardContent>
                    <Typography variant="h5" align="center" gutterBottom>
                        {user.username || "Unknown User"}
                    </Typography>
                    <Typography variant="body1" sx={{ mb: 1 }}>
                        <strong>Name:</strong> {user.name || "N/A"}
                    </Typography>
                    <Typography variant="body1" sx={{ mb: 1 }}>
                        <strong>Email:</strong> {user.email || "N/A"}
                    </Typography>
                    <Typography variant="body1" sx={{ mb: 1 }}>
                        <strong>Age:</strong> {user.age || "N/A"}
                    </Typography>
                </CardContent>
            </Card>
        </Box>
    );
}
export default Profile;