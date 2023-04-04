namespace NewShore.Infrastructure.Wrapper
{
	using Dtos.Flights;
	using Serialization;
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
			RestResponse response = this.client.Get( request );
			List<Flight> a = Serializer.Deserialize<List<Flight>>( response.Content );
			return a;
		}
	}
}
