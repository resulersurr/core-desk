import axios from "axios";
import { env } from "../../lib/env";
import { tokenStorage } from "../auth/tokenStorage";

console.log("API BASE URL:", env.apiBaseUrl);

export const apiClient = axios.create({
  baseURL: env.apiBaseUrl,
  headers: {
    "Content-Type": "application/json",
  },
});

apiClient.interceptors.request.use((config) => {
  const token = tokenStorage.getToken();

  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }

  return config;
});