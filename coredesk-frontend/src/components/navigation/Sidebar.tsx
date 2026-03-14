import { Link, useLocation } from "react-router-dom";

const menuItems = [
  { label: "Dashboard", path: "/dashboard" },
  { label: "Projects", path: "/projects" },
  { label: "Tasks", path: "/tasks" },
  { label: "Notes", path: "/notes" },
];

export default function Sidebar() {
  const location = useLocation();

  return (
    <aside className="w-64 bg-slate-900 text-white flex flex-col">
      <div className="px-6 py-5 text-xl font-bold border-b border-slate-800">
        CoreDesk
      </div>

      <nav className="flex-1 p-4 space-y-2">
        {menuItems.map((item) => {
          const active = location.pathname === item.path;

          return (
            <Link
              key={item.path}
              to={item.path}
              className={`block rounded-lg px-4 py-2 transition ${
                active
                  ? "bg-slate-700 text-white"
                  : "text-slate-300 hover:bg-slate-800 hover:text-white"
              }`}
            >
              {item.label}
            </Link>
          );
        })}
      </nav>
    </aside>
  );
}