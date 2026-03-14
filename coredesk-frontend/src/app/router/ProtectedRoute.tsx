import { Navigate, Outlet } from "react-router-dom";
import { tokenStorage } from "../../services/auth/tokenStorage";

export default function ProtectedRoute() {
  const isAuthenticated = tokenStorage.isAuthenticated();

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }

  return <Outlet />;
}