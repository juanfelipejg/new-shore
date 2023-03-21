namespace NewShore.Application.Services.Journeys
{
	using System.Net;
	using System.Web.Http;
	using Domain.Models.Flights;
	using Domain.Models.Journeys;
	using Domain.Serivces.Flights;
	public class JourneyService: IJourneyService
	{
		private readonly IFlightsGetter _flightsGetter;

		public JourneyService( IFlightsGetter flightsGetter )
		{
			this._flightsGetter = flightsGetter;
		}
		public Journey Get( Dtos.Journeys.Journey journey )
		{
			IEnumerable<Flight> flights = this._flightsGetter.Get();

			IEnumerable<Flight> route = CalculateRoute( journey, flights );

			decimal price = route.Sum( f => f.Price );

			return new Journey( journey.Origin, journey.Destination, price, route );
		}

		private static IEnumerable<Flight> CalculateRoute( Dtos.Journeys.Journey journey, IEnumerable<Flight> flights )
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

			var response = new HttpResponseMessage( HttpStatusCode.NotFound )
			{
				Content = new StringContent( $"No se pudo encontrar una ruta para el viaje seleccionado" )
			};

			throw new HttpResponseException( response );
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
