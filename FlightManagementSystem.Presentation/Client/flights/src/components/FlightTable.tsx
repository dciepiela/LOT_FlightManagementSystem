import { useEffect, useState } from "react";
import { Flight } from "../models/flight";
import apiConnector from "../interceptors/apiConnector";
import { Button, Container } from "semantic-ui-react";
import FlightTableItem from "./FlightTableItem";
import { NavLink } from "react-router-dom";

export default function FlightTable() {
  const [flights, setFlights] = useState<Flight[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const fetchedFlights = await apiConnector.getFlights();
      setFlights(fetchedFlights);
    };

    fetchData();
  }, []);
  return (
    <div>
      <Container className="container-style">
        <table className="ui inverted table">
          <thead style={{ textAlign: "center" }}>
            <tr>
              <th>Id</th>
              <th>Numer lotu</th>
              <th>Data wylotu</th>
              <th>Miejsce wylotu</th>
              <th>Miejsce przylotu</th>
              <th>Typ samolotu</th>
            </tr>
          </thead>
          <tbody>
            {flights.length !== 0 &&
              flights.map((flight, index) => (
                <FlightTableItem key={index} flight={flight} />
              ))}
          </tbody>
        </table>
        <Button
          as={NavLink}
          to="createFlight"
          floated="right"
          type="button"
          content="Utwórz lot"
          positive
        />
      </Container>
    </div>
  );
}
