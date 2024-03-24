import "./App.css";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { SignInPage } from "./pages";

export function App(): JSX.Element {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <SignInPage />
    }
  ]);

  return (
    <RouterProvider
      router={router}
    />
  );
}
