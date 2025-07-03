import React from "react";
import{Navigate} from "react-router-dom";
import { getCurrentUser } from "../services/authService";

interface Props{
    children: React.ReactElement;
}

const ProtectedRoute: React.FC<Props> = ({children}) => {
    const user = getCurrentUser();
    return user ? children : <Navigate to="/login" />
}

export default ProtectedRoute;