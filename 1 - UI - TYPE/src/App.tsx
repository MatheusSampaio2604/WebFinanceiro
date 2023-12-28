import { useEffect, useState } from 'react'

import './App.css'
import SignIn from './pages/Authentication/SignIn';
import { Route, Routes } from 'react-router';
import Dashboard from './pages/Dashboard/Dashboard';


function App() {
    const [loading, setLoading] = useState<boolean>(true);

    const preloader = document.getElementById('preloader');

    if (preloader) {
        setTimeout(() => {
            preloader.style.display = 'none';
            setLoading(false);
        }, 2000);
    }

    useEffect(() => {
        setTimeout(() => setLoading(false), 1000);
    }, []);


    return (
        <>
            <Routes>
                <Route
                    path="/login"
                    element={<SignIn />}
                />
                <Route
                    path="/"
                    element={<Dashboard />}
                />
                
            </Routes>
        </>
    );
}

export default App;
