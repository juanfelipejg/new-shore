using NewShore.Domain.Models.Journeys;
using NewShore.Domain.Serivces.Flights;

namespace NewShore.Application.Services.Journeys
{
	public class JourneyService: IJourneyService
	{
		private readonly IFlightsGetter _flightsGetter;

		public JourneyService( IFlightsGetter flightsGetter )
		{
			this._flightsGetter = flightsGetter;
		}
		public Journey Get( Dtos.Journeys.Journey journey )
		{
			List<Domain.Models.Flights.Flight> flights = _flightsGetter.Get();
			return new Journey();
		}
	}
}
