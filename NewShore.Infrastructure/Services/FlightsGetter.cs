using AutoMapper;
using NewShore.Domain.Models.Flights;
using NewShore.Domain.Serivces.Flights;
using NewShore.Infrastructure.Wrapper;
using RestSharp;

namespace NewShore.Infrastructure.Services
{
	public class FlightsGetter: IFlightsGetter
	{
		private readonly IRestClientWrapper restClientWrapper;
		private readonly IMapper mapper;

		public FlightsGetter( IRestClientWrapper restClientWrapper, IMapper mapper )
		{
			this.restClientWrapper = restClientWrapper;
			this.mapper = mapper;
		}

		public IEnumerable<Flight> Get()
		{
			var request = new RestRequest( "/2" );
			List<Dtos.Flights.Flight> response = this.restClientWrapper.GetFlights( request );
			return this.mapper.Map<IEnumerable<Infrastructure.Dtos.Flights.Flight>, IEnumerable<Flight>>( response );
		}
	}
}
