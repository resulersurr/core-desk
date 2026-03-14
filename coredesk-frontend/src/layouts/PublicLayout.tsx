import { Outlet } from "react-router-dom";
import Navbar from "../components/navigation/Navbar";

export default function PublicLayout() {
  return (
    <div style={{ minHeight: "100vh", background: "#f8fafc" }}>
      <Navbar />
      <main>
        <Outlet />
      </main>
    </div>
  );
}