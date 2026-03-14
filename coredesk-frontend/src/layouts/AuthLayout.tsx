import { Outlet } from "react-router-dom";

export default function AuthLayout() {
  return (
    <div
      style={{
        minHeight: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        padding: "24px",
        background: "#f1f5f9",
      }}
    >
      <div style={{ width: "100%", maxWidth: "420px" }}>
        <Outlet />
      </div>
    </div>
  );
}