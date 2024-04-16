import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import FlightForm from "../components/FlightForm";
import FlightTable from "../components/FlightTable";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      { path: "createFlight", element: <FlightForm key="create" /> },
      { path: "editFlight/:id", element: <FlightForm key="edit" /> },
      { path: "*", element: <FlightTable /> },
    ],
  },
];

export const router = createBrowserRouter(routes);
