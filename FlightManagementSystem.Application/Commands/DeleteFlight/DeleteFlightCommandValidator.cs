using FlightManagementSystem.Domain;
using FluentValidation;

namespace FlightManagementSystem.Application.Commands.DeleteFlight
{
    public class DeleteFlightCommandValidator : AbstractValidator<DeleteFlightCommand>{
        public DeleteFlightCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage($"{nameof(Flight.Id)} nie może być puste");
        }
    }
}
