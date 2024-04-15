using FlightManagementSystem.Domain;
using FluentValidation;

namespace FlightManagementSystem.Application.Commands.CreateFlight
{
    public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightCommandValidator()
        {
            RuleFor(x => x.FlightNumber)
                .NotEmpty()
                .WithMessage($"{nameof(Flight.FlightNumber)} nie może być puste")
                .MaximumLength(30)
                .WithMessage($"{nameof(Flight.FlightNumber)} nie może być dłuższe niż 30 znaków");

            RuleFor(x => x.DateDeparture)
               .NotEmpty()
               .WithMessage($"{nameof(Flight.DateDeparture)} nie może być puste")
               .Must(BeAValidDate)
               .WithMessage($"{nameof(Flight.DateDeparture)} musi być prawidłową datą");

            RuleFor(x => x.PlaceDeparture)
               .NotEmpty()
               .WithMessage($"{nameof(Flight.PlaceDeparture)} nie może być puste");

            RuleFor(x => x.PlaceArrival)
                .NotEmpty()
                .WithMessage($"{nameof(Flight.PlaceArrival)} nie może być puste");

            RuleFor(x => x.AircraftType)
                .IsInEnum()
                .WithMessage("Nieprawidłowy typ samolotu");
        }
        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.UtcNow;
        }
    }
}