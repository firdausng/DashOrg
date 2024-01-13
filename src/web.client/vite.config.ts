import { fileURLToPath, URL } from 'node:url';
import { defineConfig } from 'vite';
import react from "@vitejs/plugin-react-swc";

// https://vitejs.dev/config/
export default defineConfig({
    // css: {
    //     postcss: {
    //         plugins: [
    //             tailwindcss()
    //         ],
    //     },
    // },
    plugins: [react()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '^/weatherforecast': {
                target: 'https://localhost:5001/',
                secure: false
            }
        },
        port: 5173,
    }
})
