export default function DashboardPage() {
  return (
    <div>
      <h1>Dashboard</h1>

      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(3, 1fr)",
          gap: "20px",
          marginTop: "20px",
        }}
      >
        <div style={card}>Projects: 5</div>
        <div style={card}>Tasks: 23</div>
        <div style={card}>Notes: 12</div>
      </div>
    </div>
  );
}

const card = {
  background: "#fff",
  padding: "24px",
  borderRadius: "12px",
  boxShadow: "0 4px 12px rgba(0,0,0,0.05)",
};