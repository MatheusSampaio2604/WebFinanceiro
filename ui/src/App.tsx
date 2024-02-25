import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import SignIn from './components/authentication/SignIn';
import SignUp from './components/authentication/SignUp';
import DashBoard from './components/DashBoard/DashBoard';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<DashBoard />} />
                <Route path="/login" element={<SignIn />} />
                <Route path="/register" element={<SignUp />} />
            </Routes>
        </Router>
    );
}

export default App;
