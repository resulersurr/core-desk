export default function ProductsPage() {
  return (
    <div className="max-w-6xl mx-auto px-6 py-20">

      <h1 className="text-4xl font-bold mb-10 text-center">
        CoreDesk Modülleri
      </h1>

      <div className="grid md:grid-cols-3 gap-6">

        <div className="bg-white border rounded-xl p-6">
          <h3 className="font-bold text-lg mb-2">Project Management</h3>
          <p className="text-gray-600">
            Projelerinizi kolayca oluşturun ve yönetin.
          </p>
        </div>

        <div className="bg-white border rounded-xl p-6">
          <h3 className="font-bold text-lg mb-2">Task Tracking</h3>
          <p className="text-gray-600">
            Görevleri ekip üyelerine atayın ve ilerlemeyi takip edin.
          </p>
        </div>

        <div className="bg-white border rounded-xl p-6">
          <h3 className="font-bold text-lg mb-2">Team Collaboration</h3>
          <p className="text-gray-600">
            Ekibinizle birlikte çalışın ve tüm süreçleri yönetin.
          </p>
        </div>

      </div>

    </div>
  );
}