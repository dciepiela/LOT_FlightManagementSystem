using FlightManagementSystem.Domain;
using FluentValidation;

namespace FlightManagementSystem.Application.Queries.GetFlightById
{
    public class GetFlightByIdQueryValidator : AbstractValidator<GetFlightByIdQuery>
    {
        public GetFlightByIdQueryValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage($"{nameof(Flight.Id)} nie może być puste");
        }
    }
}
