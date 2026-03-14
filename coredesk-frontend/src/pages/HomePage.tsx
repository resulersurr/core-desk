import { Link } from "react-router-dom";

export default function HomePage() {
  return (
    <div className="max-w-6xl mx-auto px-6 py-20">

      <div className="text-center">

        <h1 className="text-5xl font-bold mb-6">
          Modern ekipler için proje yönetimi
        </h1>

        <p className="text-gray-600 text-lg mb-8">
          CoreDesk ile projelerinizi, görevlerinizi ve ekibinizi tek platformda yönetin.
        </p>

        <div className="flex justify-center gap-4">
          <Link
            to="/login"
            className="bg-black text-white px-6 py-3 rounded-lg"
          >
            Ücretsiz Başla
          </Link>

          <Link
            to="/products"
            className="border px-6 py-3 rounded-lg"
          >
            Ürünleri İncele
          </Link>
        </div>

      </div>

    </div>
  );
}