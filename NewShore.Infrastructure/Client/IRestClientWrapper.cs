namespace NewShore.Infrastructure.Wrapper
{
	using Dtos.Flights;
	using RestSharp;
	public interface IRestClientWrapper
	{
		List<Flight> GetFlights( RestRequest request );
	}
}
