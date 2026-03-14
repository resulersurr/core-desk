import { createBrowserRouter } from "react-router-dom";
import AuthLayout from "../../layouts/AuthLayout";
import DashboardLayout from "../../layouts/DashboardLayout";
import PublicLayout from "../../layouts/PublicLayout";

import LoginPage from "../../pages/auth/LoginPage";
import DashboardPage from "../../pages/dashboard/DashboardPage";
import HomePage from "../../pages/HomePage";
import ProductsPage from "../../pages/ProductsPage";

import ProtectedRoute from "./ProtectedRoute";
import GuestRoute from "./GuestRoute";

const placeholderStyle: React.CSSProperties = {
  background: "#ffffff",
  border: "1px solid #e2e8f0",
  borderRadius: "16px",
  padding: "24px",
};

function ProjectsPage() {
  return (
    <div style={placeholderStyle}>
      <h2 style={{ marginTop: 0 }}>Projects</h2>
      <p style={{ marginBottom: 0, color: "#64748b" }}>
        Projects sayfası hazırlanıyor.
      </p>
    </div>
  );
}

function TasksPage() {
  return (
    <div style={placeholderStyle}>
      <h2 style={{ marginTop: 0 }}>Tasks</h2>
      <p style={{ marginBottom: 0, color: "#64748b" }}>
        Tasks sayfası hazırlanıyor.
      </p>
    </div>
  );
}

function NotesPage() {
  return (
    <div style={placeholderStyle}>
      <h2 style={{ marginTop: 0 }}>Notes</h2>
      <p style={{ marginBottom: 0, color: "#64748b" }}>
        Notes sayfası hazırlanıyor.
      </p>
    </div>
  );
}

function NotFoundPage() {
  return <div>Sayfa bulunamadı</div>;
}

export const router = createBrowserRouter([
  {
    element: <PublicLayout />,
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
      {
        path: "/products",
        element: <ProductsPage />,
      },
    ],
  },
  {
    element: <GuestRoute />,
    children: [
      {
        element: <AuthLayout />,
        children: [
          {
            path: "/login",
            element: <LoginPage />,
          },
        ],
      },
    ],
  },
  {
    element: <ProtectedRoute />,
    children: [
      {
        element: <DashboardLayout />,
        children: [
          {
            path: "/dashboard",
            element: <DashboardPage />,
          },
          {
            path: "/projects",
            element: <ProjectsPage />,
          },
          {
            path: "/tasks",
            element: <TasksPage />,
          },
          {
            path: "/notes",
            element: <NotesPage />,
          },
        ],
      },
    ],
  },
  {
    path: "*",
    element: <NotFoundPage />,
  },
]);