import { Box, Button, Checkbox, Container, CssBaseline, FormControlLabel, Link, TextField, Typography, useMediaQuery, createTheme, ThemeProvider } from '@mui/material';
import { useState } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import Host, { Port } from '../../config/linkConfig';

const theme = createTheme();

const SignIn = () => {
    const [authenticated, setAuthenticated] = useState(false);
    const [usernameInput, setUserName] = useState("");
    const [passwordInput, setPassword] = useState("");

    const navigate = useNavigate();
    const isSmallScreen = useMediaQuery(theme.breakpoints.down('sm'));

    const handleSubmit = (event: { preventDefault: () => void; }) => {

        event.preventDefault();

        const login = {
            email: usernameInput,
            senha: passwordInput
        };

        fetch(Host + Port + '/Api/Users/CreateTokenIdentity', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(login)
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

                navigate('/', { replace: true });
            })
            .catch((error) => {
                if (error.message === 'Unauthorized') {
                    console.log('Credenciais inválidas');
                } else {
                    console.log(login, 'Falha no login');
                }
                console.error(error);
            })
            ;
    };


    if (authenticated) {
        return <Navigate to="/" replace />;
    } else {
        return (
            <ThemeProvider theme={theme}>
                <CssBaseline />
                <Box
                    sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        minHeight: '100vh',
                        backgroundImage: `url(https://www.skillstork.org/blog/wp-content/uploads/2022/11/modern-education-Skillstork-1568x882.jpg)`,
                        backgroundPosition: 'center',
                        backgroundSize: 'cover',
                        backgroundRepeat: 'no-repeat',
                        backgroundAttachment: 'fixed',
                        textDecoration: 'none',
                        color: theme => theme.palette.secondary.main,
                    }}
                >
                    <Container component="main" maxWidth={isSmallScreen ? 'xs' : 'md'}>

                        <Typography component="span" variant="h5">
                            Login
                        </Typography>

                        <Box component="form" onSubmit={handleSubmit}  >
                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                id="user"
                                label="Email"
                                name="username"
                                autoComplete="username"
                                autoFocus
                                required
                                value={usernameInput}
                                onChange={e => setUserName(e.target.value)}
                            />

                            <TextField
                                variant="outlined"
                                margin="normal"
                                fullWidth
                                required
                                name="password"
                                label="Senha"
                                type="password"
                                id="pass"
                                autoComplete="current-password"
                                value={passwordInput}
                                onChange={e => setPassword(e.target.value)}
                            />

                            <FormControlLabel
                                control={<Checkbox value="remember" color="primary" />}
                                label="Manter Conectado"
                            />

                            <Link href="#" variant="body2">
                                Esqueci a senha...
                            </Link>

                            <Button
                                type="submit"
                                fullWidth
                                variant="contained"
                                color="success"
                            >
                                Login
                            </Button>

                            <Typography>
                                Ainda não tem uma conta? <Link href="/register">Registre agora</Link>
                            </Typography>
                        </Box>

                    </Container>
                </Box>
            </ThemeProvider>
        );
    }
};

export default SignIn;
