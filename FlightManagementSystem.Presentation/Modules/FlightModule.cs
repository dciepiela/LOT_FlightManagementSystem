using FlightManagementSystem.Application.Commands.CreateFlight;
using FlightManagementSystem.Application.Commands.DeleteFlight;
using FlightManagementSystem.Application.Commands.UpdateFlight;
using FlightManagementSystem.Application.DTO;
using FlightManagementSystem.Application.Queries.GetFlightById;
using FlightManagementSystem.Application.Queries.GetFlights;
using MediatR;

namespace FlightManagementSystem.Presentation.Modules
{
    public static class FlightModule
    { 
        public static void AddFlightsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/flights", async (IMediator mediator, CancellationToken ct) =>
            {
                var flights = await mediator.Send(new GetFlightsQuery(), ct);
                return Results.Ok(flights);
            }).WithTags("Flights")
            .RequireAuthorization();

            app.MapGet("/api/flights/{id}", async (IMediator mediator,int id, CancellationToken ct) =>
            {
                var flight = await mediator.Send(new GetFlightByIdQuery(id), ct);
                return Results.Ok(flight);
            }).WithTags("Flights");

            app.MapPost("/api/flights", async (IMediator mediator, CreateFlightDto flightDto, CancellationToken ct) =>
            {
                var createFlight = new CreateFlightCommand(flightDto.FlightNumber, 
                    flightDto.DateDeparture, 
                    flightDto.PlaceDeparture, 
                    flightDto.PlaceArrival, 
                    flightDto.AircraftType);

                var result = await mediator.Send(createFlight, ct);
                return Results.Ok(result);
            }).WithTags("Flights");

            app.MapPut("/api/flights/{id}", async (IMediator mediator, int id, UpdateFlightDto flightDto, CancellationToken ct) =>
            {
                var updateFlight = new UpdateFlightCommand(id,
                    flightDto.FlightNumber,
                    flightDto.DateDeparture,
                    flightDto.PlaceDeparture,
                    flightDto.PlaceArrival,
                    flightDto.AircraftType);

                var result = await mediator.Send(updateFlight, ct);
                return Results.Ok(result);
            }).WithTags("Flights");

            app.MapDelete("/api/flights/${id}", async (IMediator mediator, int id, CancellationToken ct) =>
            {
                var deleteFlight = new DeleteFlightCommand(id);
                var result = await mediator.Send(deleteFlight, ct);
                return Results.Ok(result);
            }).WithTags("Flights");
        }
    }
}
