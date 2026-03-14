import { Navigate, Outlet } from "react-router-dom";
import { tokenStorage } from "../../services/auth/tokenStorage";

export default function GuestRoute() {
  const isAuthenticated = tokenStorage.isAuthenticated();

  if (isAuthenticated) {
    return <Navigate to="/dashboard" replace />;
  }

  return <Outlet />;
}