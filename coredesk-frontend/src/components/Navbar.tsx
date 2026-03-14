import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav className="bg-white border-b">
      <div className="max-w-6xl mx-auto flex justify-between items-center h-16 px-6">

        <Link to="/" className="text-xl font-bold">
          CoreDesk
        </Link>

        <div className="flex gap-6 items-center">
          <Link to="/" className="text-gray-600 hover:text-black">
            Ana Sayfa
          </Link>

          <Link to="/products" className="text-gray-600 hover:text-black">
            Ürünler
          </Link>

          <Link to="/login" className="text-gray-600 hover:text-black">
            Giriş
          </Link>

          <Link
            to="/login"
            className="bg-black text-white px-4 py-2 rounded-lg"
          >
            Başla
          </Link>
        </div>
      </div>
    </nav>
  );
}