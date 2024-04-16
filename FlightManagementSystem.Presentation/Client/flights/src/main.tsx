import ReactDOM from "react-dom/client";
import "semantic-ui-css/semantic.min.css";
import "./App.css";
import { RouterProvider } from "react-router-dom";
import { router } from "./router/Router.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <RouterProvider router={router} />
);
