using FlightManagementSystem.Application.Errors;

namespace FlightManagementSystem.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(List<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public List<ValidationError> ValidationErrors { get; set; }
    }
}
