namespace NewShore.Infrastructure.Wrapper
{
	using Dtos.Flights;
	using RestSharp;
	
	public class RestClientWrapper: IRestClientWrapper
	{
		private readonly RestClient client;

		public RestClientWrapper()
		{
			this.client = new RestClient( "https://recruiting-api.newshore.es/api/flights" );
		}

		public List<Flight> GetFlights( RestRequest request )
		{
			return this.client.Get<List<Flight>>( request );
		}
	}
}
