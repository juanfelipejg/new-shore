namespace NewShore.Infrastructure.Services
{
	using AutoMapper;
	using Domain.Models.Flights;
	using Domain.Serivces.Flights;
	using RestSharp;
	using Wrapper;

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
			return this.mapper.Map<IEnumerable<Dtos.Flights.Flight>, IEnumerable<Flight>>( response );
		}
	}
}
