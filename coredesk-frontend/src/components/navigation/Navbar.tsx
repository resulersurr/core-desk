import { useAuth } from "../../hooks/useAuth";

export default function Navbar() {
  const { logout } = useAuth();

  return (
    <header className="h-16 bg-white border-b border-slate-200 flex items-center justify-between px-6">
      <h1 className="text-lg font-semibold text-slate-800">CoreDesk Panel</h1>

      <button
        onClick={logout}
        className="rounded-lg bg-slate-900 px-4 py-2 text-sm font-medium text-white hover:bg-slate-800"
      >
        Çıkış Yap
      </button>
    </header>
  );
}