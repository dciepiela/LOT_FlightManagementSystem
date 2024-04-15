using FlightManagementSystem.Application.DTO;
using FlightManagementSystem.Domain;
using Mapster;

namespace FlightManagementSystem.Application.Mapping
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<List<Flight>, List<FlightDto>>
                .NewConfig()
                .Map(dest => dest, src => src);

            TypeAdapterConfig<Flight, FlightDto>
                .NewConfig()
                .Map(dest => dest, src => src);
        }
    }
}
