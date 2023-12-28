import logo from '../../images/Login/logo.png';
import backgroundLogin from '../../images/Login/backgroundLogin.jpg';
import { useState } from 'react';
import Alert from '@material-tailwind/react/components/Alert';
import "./login.css"
import { Navigate, useNavigate } from 'react-router-dom';
import Host, { Port} from '../../Conf'


const SignIn = () => {
    const [waiting, setWaiting] = useState<boolean>(false);
    const [authenticated, setAuthenticated] = useState(false);
    const [usernameInput, setUserName] = useState("");
    const [passwordInput, setPassword] = useState("");
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleSubmit = (event: { preventDefault: () => void; }) => {

        event.preventDefault();

        const formData = {
            username: usernameInput,
            password: passwordInput
        };

        setWaiting(true);

        fetch(Host + Port + '/api/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then((response) => {
                if (response.status === 200) {
                    return response.json();
                } else if (response.status === 401) {
                    throw new Error('Unauthorized');
                } else {
                    throw new Error('Login failed');
                }
            })
            .then((data) => {
                localStorage.setItem('token', data.token);
                setAuthenticated(true);

                const storedRoute = localStorage.getItem('storedRoute');
                navigate(storedRoute || '/', { replace: true });
            })
            .catch((error) => {
                if (error.message === 'Unauthorized') {
                    setError('Credenciais inválidas');
                } else {
                    setError('Falha no login');
                }
                console.error(error);
            })
            .finally(() => {
                setWaiting(false);

            });
    };

    document.body.addEventListener('loginForm', handleSubmit);

    if (authenticated) {
        return <Navigate to="/" replace />;
    } else {
        return (
            <div style={{
                backgroundImage: `url(${backgroundLogin})`, backgroundRepeat: 'no-repeat', height: '100vh'
            }}>
                <div className="rounded-sm dark:border-strokedark dark:bg-boxdark d-flex justify-content-center" style={{
                    display: 'flex',
                    justifyContent: 'center', width: 'auto'
                }}>
                    <div className="flex flex-wrap items-center" >
                        <div className="bg-white bg-opacity-70 w-full mt-4 rounded-lg" style={{ width: '500px', boxShadow: 'rgba(0, 0, 0, 0.3) 0px 19px 38px, rgba(0, 0, 0, 0.22) 0px 15px 12px' }}>
                            <div className="w-full p-4 sm:p-12.5 xl:p-17.5">
                                <div className="" style={{
                                    display: 'flex',
                                    justifyContent: 'center'
                                }}>
                                    <img className="mb-5" src={logo} alt="Logo" style={{


                                    }} />
                                    {/* 
                                   <img className="mb-5 bg-black" src={Logo2} alt="Logo" style={{ 
                                                                     width: '125px', height: '42px'}} 
                                */}
                                </div>
                                <div >
                                    {error && (
                                        <div className="border px-4 py-3 rounded relative alert-danger" >
                                            <Alert >
                                                <span >
                                                    <strong className="font-bold" >Não autorizado:</strong> {error}
                                                </span>
                                            </Alert>
                                        </div>
                                    )}
                                </div>
                                <form onSubmit={handleSubmit} id="loginForm" name="loginForm">
                                    <div className="mt-2 mb-4">
                                        <label className="mb-2.5 block font-medium text-black dark:text-white">
                                            Usuário
                                        </label>
                                        <div className="relative">
                                            <input
                                                type="email"
                                                id="username"
                                                name="username"
                                                placeholder=""
                                                value={usernameInput}
                                                autoComplete='current-text'
                                                onChange={e => setUserName(e.target.value)}
                                                className="w-full rounded-lg border border-stroke bg-transparent py-4 pl-6 pr-10 outline-none focus:border-primary focus-visible:shadow-none dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                                                required
                                            />
                                        </div>
                                    </div>

                                    <div className="mb-6">
                                        <label className="mb-2.5 block font-medium text-black dark:text-white">
                                            Senha
                                        </label>
                                        <div className="relative">
                                            <input
                                                id="password"
                                                name="password"
                                                type="password"
                                                value={passwordInput}
                                                autoComplete='current-password'
                                                onChange={e => setPassword(e.target.value)}
                                                className="w-full rounded-lg border border-stroke bg-transparent py-4 pl-6 pr-10 outline-none focus:border-primary focus-visible:shadow-none dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                                                required
                                            />
                                        </div>
                                    </div>

                                    <div className="mb-5">
                                        <input
                                            type="submit"
                                            value="Entrar"
                                            className="w-full cursor-pointer rounded-lg border border-primary bg-primary p-4 text-white transition hover:bg-opacity-90"
                                        />
                                    </div>

                                </form>
                                {waiting ? <div className="flex justify-center">
                                    <div className="h-4 w-4 animate-spin rounded-full border-2 border-solid border-primary border-t-transparent "></div>

                                </div>
                                    : <></>}

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }


};

export default SignIn;
