import { useState } from "react";
import type { FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { apiClient } from "../../services/api/client";
import { tokenStorage } from "../../services/auth/tokenStorage";

type LoginResponse = {
  token: string;
  fullName?: string;
  email?: string;
};

export default function LoginPage() {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  async function handleSubmit(e: FormEvent) {
    e.preventDefault();

    try {
      setLoading(true);
      setError("");

      const response = await apiClient.post<LoginResponse>("/api/Auth/login", {
        email,
        password,
      });

      console.log("LOGIN RESPONSE:", response.data);

      tokenStorage.setToken(response.data.token);
      navigate("/dashboard");
    } catch (err) {
      console.error("LOGIN ERROR:", err);

      if (axios.isAxiosError(err)) {
        setError(err.response?.data?.message || err.message || "Login hatası oluştu.");
      } else {
        setError("Beklenmeyen bir hata oluştu.");
      }
    } finally {
      setLoading(false);
    }
  }

  return (
    <div
      style={{
        background: "#ffffff",
        border: "1px solid #e2e8f0",
        borderRadius: "20px",
        padding: "32px",
        boxShadow: "0 10px 30px rgba(15, 23, 42, 0.06)",
      }}
    >
      <h1
        style={{
          margin: 0,
          fontSize: "28px",
          fontWeight: 700,
          color: "#0f172a",
        }}
      >
        CoreDesk Giriş
      </h1>

      <p
        style={{
          marginTop: "8px",
          marginBottom: "24px",
          color: "#64748b",
          fontSize: "14px",
        }}
      >
        Hesabınızla giriş yapın.
      </p>

      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: "16px" }}>
          <label
            style={{
              display: "block",
              marginBottom: "8px",
              fontSize: "14px",
              fontWeight: 600,
            }}
          >
            E-posta
          </label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="ornek@firma.com"
            style={{
              width: "100%",
              height: "44px",
              padding: "0 14px",
              borderRadius: "12px",
              border: "1px solid #cbd5e1",
              outline: "none",
            }}
          />
        </div>

        <div style={{ marginBottom: "16px" }}>
          <label
            style={{
              display: "block",
              marginBottom: "8px",
              fontSize: "14px",
              fontWeight: 600,
            }}
          >
            Şifre
          </label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="********"
            style={{
              width: "100%",
              height: "44px",
              padding: "0 14px",
              borderRadius: "12px",
              border: "1px solid #cbd5e1",
              outline: "none",
            }}
          />
        </div>

        {error && (
          <div
            style={{
              marginBottom: "16px",
              background: "#fef2f2",
              color: "#dc2626",
              padding: "12px 14px",
              borderRadius: "12px",
              fontSize: "14px",
            }}
          >
            {error}
          </div>
        )}

        <button
          type="submit"
          disabled={loading}
          style={{
            width: "100%",
            height: "46px",
            border: "none",
            borderRadius: "12px",
            background: "#0f172a",
            color: "#ffffff",
            fontWeight: 600,
            cursor: "pointer",
          }}
        >
          {loading ? "Giriş yapılıyor..." : "Giriş Yap"}
        </button>
      </form>
    </div>
  );
}