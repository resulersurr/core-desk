import { tokenStorage } from "../services/auth/tokenStorage";

export function useAuth() {
  const isAuthenticated = tokenStorage.isAuthenticated();

  const logout = () => {
    tokenStorage.clearToken();
    window.location.href = "/login";
  };

  return {
    isAuthenticated,
    logout,
  };
}