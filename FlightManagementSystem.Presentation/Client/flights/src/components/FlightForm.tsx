import { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import { AircraftType, Flight } from "../models/flight";
import apiConnector from "../interceptors/apiConnector";
import { Button, DropdownProps, Form, Segment } from "semantic-ui-react";

export default function FlightForm() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [flight, setFlight] = useState<Flight>({
    id: undefined,
    flightNumber: "",
    dateDeparture: "",
    placeDeparture: "",
    placeArrival: "",
    aircraftType: AircraftType.Embraer,
  });

  useEffect(() => {
    if (id) {
      apiConnector.getFlightById(id).then((flight) => setFlight(flight!));
    }
  }, [id]);

  function handleSubmit() {
    if (!flight.id) {
      apiConnector.createFlight(flight).then(() => navigate("/"));
    } else {
      apiConnector.editFlight(flight).then(() => navigate("/"));
    }
  }

  function handleInputChange(e: ChangeEvent<HTMLInputElement>) {
    const { name, value } = e.target;
    setFlight({ ...flight, [name]: value });
  }

  function handleSelectChange(
    _: SyntheticEvent<HTMLElement, Event>,
    data: DropdownProps
  ) {
    const { name, value } = data;
    setFlight({ ...flight, [name as string]: value });
  }

  return (
    <Segment clearing inverted>
      <Form
        onSubmit={handleSubmit}
        autoComplete="off"
        className="ui inverted form"
      >
        <Form.Input
          label="Numer lotu"
          placeholder="Numer lotu"
          name="flightNumber"
          value={flight.flightNumber}
          onChange={handleInputChange}
        />
        <Form.Field>
          <label>Data wylotu</label>
          <input
            type="datetime-local"
            placeholder="Data wylotu"
            name="dateDeparture"
            value={flight.dateDeparture}
            onChange={handleInputChange}
          />
        </Form.Field>
        <Form.Input
          label="Miejsce odlotu"
          placeholder="Miejsce odlotu"
          name="placeDeparture"
          value={flight.placeDeparture}
          onChange={handleInputChange}
        />
        <Form.Input
          label="Miejsce przylotu"
          placeholder="Miejsce przylotu"
          name="placeArrival"
          value={flight.placeArrival}
          onChange={handleInputChange}
        />
        <Form.Select
          label="Rodzaj samolotu"
          name="aircraftType"
          value={flight.aircraftType}
          onChange={handleSelectChange}
          options={[
            {
              key: AircraftType.Embraer,
              text: "Embraer",
              value: AircraftType.Embraer,
            },
            {
              key: AircraftType.Boeing,
              text: "Boeing",
              value: AircraftType.Boeing,
            },
            {
              key: AircraftType.Airbus,
              text: "Airbus",
              value: AircraftType.Airbus,
            },
          ]}
        />
        <Button floated="right" positive type="submit" content="Zatwierdź" />
        <Button
          as={NavLink}
          to="/"
          floated="right"
          type="button"
          content="Wróć"
        />
      </Form>
    </Segment>
  );
}
