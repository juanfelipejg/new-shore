namespace NewShore.Application
{
	public class RouteNotFound: Exception
	{
		public RouteNotFound(): base( "No se encontraron vuelos" ) { }
	}
}
