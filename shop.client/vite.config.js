import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
    plugins: [react()],
    server: {
        port: 58237,
        proxy: {
            '/weatherforecast': {
                target: 'http://shop.server:8080', // container name + HTTP
                changeOrigin: true,
                secure: false
            }
        }
    }
})
