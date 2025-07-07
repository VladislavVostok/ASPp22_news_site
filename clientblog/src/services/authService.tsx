import axios from "axios";
import type { User} from "../types";

const API_URL = "http://localhost:5000/api/Auth/";

export const login = async (email: string, password: string): Promise<User> => {

    const response = await axios.post<{token:string, email:string}>(API_URL + "login", {email, password});
    if(response.data.token){
        localStorage.setItem("user", JSON.stringify(response.data));
    }
    return response.data;
};

export const register = async (email: string, password:string) =>{
    return await axios.post(API_URL + "register", {email, password});
};

export const logout = () => {
    localStorage.removeItem("user");
};

export const getCurrentUser = () : User | null => {
    const userStr = localStorage.getItem("user");
    return userStr ? JSON.parse(userStr) : null;
};