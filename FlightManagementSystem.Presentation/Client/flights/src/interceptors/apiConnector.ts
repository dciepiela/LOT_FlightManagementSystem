import axios, { AxiosResponse } from "axios";
import { Flight } from "../models/flight";

export const API_BASE_URL = "http://localhost:5001/api";

const apiConnector = {

    getFlights: async () : Promise<Flight[]> => {
        const response: AxiosResponse<Flight[]> = await axios.get(`${API_BASE_URL}/flights`);
        const flights = response.data.map(flight => ({
            ...flight,
            dateDeparture: flight.dateDeparture ? flight.dateDeparture.substring(0, 10) + ' ' + flight.dateDeparture.substring(11, 16) : ""
        }));
        return flights;
    },

    createFlight: async (flight: Flight): Promise<void> => {
        await axios.post<number>(`${API_BASE_URL}/flights`, flight);
    },
    
    editFlight: async (flight: Flight) : Promise<void> => {
        await axios.put<number>(`${API_BASE_URL}/flights/${flight.id}`, flight);
    },
    
    deleteFlight: async (flightId: number): Promise<void> => {
        await axios.delete<string>(`${API_BASE_URL}/flights/${flightId}`);
        },
    
    getFlightById: async (flightId: string) : Promise<Flight | undefined> => {
            const response = await axios.get<Flight>(`${API_BASE_URL}/flights/${flightId}`);
            return response.data;
    }
}

export default apiConnector;