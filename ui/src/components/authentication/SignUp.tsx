import React from 'react';
import { TextField, Button, Link, Box, Container, CssBaseline, Typography } from '@mui/material';
import { createTheme, ThemeProvider } from '@mui/material/styles';

const theme = createTheme();

const SignUp: React.FC = () => {
    return (
        <ThemeProvider theme={theme}>
            <Container component="main" maxWidth="xs">
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
                    <Typography component="span" variant="h5">
                        Sign Up
                    </Typography>
                    <TextField
                        variant="outlined"
                        margin="normal"
                        fullWidth
                        id="username"
                        label="Username"
                        name="username"
                        autoComplete="username"
                        autoFocus
                    />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        fullWidth
                        name="email"
                        label="Email"
                        type="email"
                        id="email"
                        autoComplete="email"
                    />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        fullWidth
                        name="password"
                        label="Password"
                        type="password"
                        id="password"
                        autoComplete="new-password"
                    />
                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        color="primary"
                    >
                        Sign Up
                    </Button>
                    <Typography>
                        Already have an account? <Link href="/login">Login</Link>
                    </Typography>

                </Box>
            </Container>
        </ThemeProvider>
    );
};

export default SignUp;
