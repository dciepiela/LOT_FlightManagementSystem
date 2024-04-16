import { Button } from "semantic-ui-react";
import { AircraftType, Flight } from "../models/flight";
import apiConnector from "../interceptors/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
  flight: Flight;
}
export default function FlightTableItem({ flight }: Props) {
  const aircraftTypeName = AircraftType[flight.aircraftType]; // Get the name of the aircraft type

  return (
    <>
      <tr className="center aligned">
        <td data-label="Id">{flight.id}</td>
        <td data-label="FlightNumber">{flight.flightNumber}</td>
        <td data-label="DateDeparture">{flight.dateDeparture}</td>
        <td data-label="PlaceDeparture">{flight.placeDeparture}</td>
        <td data-label="PlaceArrival">{flight.placeArrival}</td>
        <td data-label="AircraftType">{aircraftTypeName}</td>
        <td data-label="Action">
          <Button
            as={NavLink}
            to={`editFlight/${flight.id}`}
            color="yellow"
            type="submit"
            content="Edytuj"
          />
          <Button
            negative
            type="button"
            content="Usuń"
            onClick={async () => {
              await apiConnector.deleteFlight(flight.id!);
              window.location.reload();
            }}
          />
        </td>
      </tr>
    </>
  );
}
