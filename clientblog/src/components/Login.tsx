import React, {useState} from "react";
import {useNavigate} from "react-router-dom";
import { login } from "../services/authService";

const Login: React.FC = () => {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [error, setError] = useState<string>("");
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {

        e.preventDefault();

        try{
            await login(email, password);
            navigate("/profile")
        }
        catch{
            setError("Неверный логин и пароль!");
        }
    };

    return(
        <form onSubmit={handleSubmit}>
            <h2>Вход</h2>
            <input type="email" value={email} onChange={e => setEmail(e.target.value)} placeholder="Email" required />
            <input type="password" value={password} onChange={e => setPassword(e.target.value)} placeholder="Пароль" required />
            <button type="submit">Войти</button>
            {error && <div style={{color: "red"}}>{error}</div>}
        </form>
    );
};

export default Login;