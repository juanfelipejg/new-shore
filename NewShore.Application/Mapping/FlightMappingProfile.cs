using AutoMapper;
using NewShore.Domain.Models.Flights;

namespace NewShore.Application.Mapping
{
	public class FlightMappingProfile: Profile
	{
		public FlightMappingProfile()
		{
			this.CreateMap<Infrastructure.Dtos.Flights.Flight, Flight>()
				.ForMember( target => target.Origin, option => option.MapFrom( source => source.DepartureStation ) )
				.ForMember( target => target.Destination, option => option.MapFrom( source => source.ArrivalStation ) )
				.ForPath( target => target.Transport.FlightCarrier, option => option.MapFrom( source => source.FlightCarrier ) )
				.ForPath( target => target.Transport.FlightNumber, option => option.MapFrom( source => source.FlightNumber ) );
		}
	}
}
