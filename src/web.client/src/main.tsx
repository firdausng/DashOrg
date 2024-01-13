import * as React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './index.css'
import { DarkThemeToggle, Flowbite  } from 'flowbite-react';


const rootElement = document.getElementById('app')!
if (!rootElement.innerHTML) {
    const root = ReactDOM.createRoot(rootElement)
    root.render(
        <React.StrictMode>
            <Flowbite>
                <main className={'bg-slate-300 dark:bg-slate-900 h-screen text-slate-700 dark:text-slate-200'}>
                    <DarkThemeToggle />
                    <App/>
                </main>
            </Flowbite>

        </React.StrictMode>,
    )
}