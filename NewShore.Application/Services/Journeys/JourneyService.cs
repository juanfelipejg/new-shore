namespace NewShore.Application.Services.Journeys
{
	using Domain.Models.Flights;
	using Domain.Models.Journeys;
	using Domain.Serivces.Flights;
	using Infrastructure.Data;

	public class JourneyService: IJourneyService
	{
		private readonly IFlightsGetter _flightsGetter;
		private readonly INewShoreContext _newShoreContext;

		public JourneyService( IFlightsGetter flightsGetter, INewShoreContext newShoreContext )
		{
			this._flightsGetter = flightsGetter;
			this._newShoreContext = newShoreContext;
		}

		public Journey Get( Dtos.Journeys.Journey journey )
		{
			try
			{
				Journey? journeySaved = this._newShoreContext.Journeys().FirstOrDefault( j => j.Origin == journey.Origin && j.Destination == j.Destination );

				if ( journeySaved == null ) {

					IEnumerable<Flight> flights = this._flightsGetter.Get();

					List<Flight> route = CalculateRoute( journey, flights );

					decimal price = route.Sum( f => f.Price );

					var journeyToSave = new Journey( journey.Origin, journey.Destination, price ) ;
					
					journeyToSave.AddFlights( route );

					this._newShoreContext.Journeys().Add( journeyToSave );
					this._newShoreContext.SaveChanges();

					return journeyToSave;
				}

				else
				{
					return journeySaved;
				}
			}

			catch ( Exception ex )
			{
				throw new ApplicationException( "Ocurrió un error al buscar un viaje. Por favor, inténtelo de nuevo más tarde.", ex );
			}
		}

		private static List<Flight> CalculateRoute( Dtos.Journeys.Journey journey, IEnumerable<Flight> flights )
		{
			var routes = new List<Flight>();
			Flight? directFlight = flights?.FirstOrDefault( f => f.Origin == journey.Origin && f.Destination == journey.Destination );

			if( directFlight != null )
			{
				routes.Add( directFlight );
				return routes;
			}

			routes = CalculateAlternativeRoutes( journey, flights );			

			if( routes.Count > 0 )
			{
				return routes;
			}

			throw new RouteNotFound();			
		}

		private static List<Flight> CalculateAlternativeRoutes( Dtos.Journeys.Journey journey, IEnumerable<Flight>? flights )
		{
			var routes = new List<Flight>();

			IEnumerable<Flight> originFlights = flights.Where( f => f.Origin == journey.Origin );

			IEnumerable<Flight> destinationFlights = flights.Where( f => f.Destination == journey.Destination );

			foreach( Flight originFlight in originFlights )
			{
				foreach( Flight destinationFlight in destinationFlights )
				{
					if( originFlight.Destination == destinationFlight.Origin )
					{
						routes.Add( originFlight );
						routes.Add( destinationFlight );
						break;
					}
				}
			}

			return routes;
		}
	}
}
