import { Link } from "react-router-dom";

export default function Sidebar() {
  return (
    <div
      style={{
        width: "240px",
        background: "#0f172a",
        color: "#fff",
        padding: "24px",
        display: "flex",
        flexDirection: "column",
        gap: "20px",
      }}
    >
      <h2 style={{ margin: 0 }}>CoreDesk</h2>

      <nav style={{ display: "flex", flexDirection: "column", gap: "12px" }}>
        <Link to="/dashboard">Dashboard</Link>
        <Link to="/projects">Projects</Link>
        <Link to="/tasks">Tasks</Link>
        <Link to="/notes">Notes</Link>
      </nav>
    </div>
  );
}