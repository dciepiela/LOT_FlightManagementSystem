export interface Flight {
    id: number | undefined,
    flightNumber: string,
    dateDeparture: string | undefined,
    placeDeparture: string,
    placeArrival: string,
    aircraftType: AircraftType
  }
  

  export enum AircraftType {
    Embraer,
    Boeing,
    Airbus
  }
