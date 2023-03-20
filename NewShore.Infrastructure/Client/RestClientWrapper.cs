using RestSharp;

namespace NewShore.Infrastructure.Wrapper
{
	public class RestClientWrapper: IRestClientWrapper
	{
		private readonly RestClient client;

		public RestClientWrapper()
		{
			this.client = new RestClient( "https://recruiting-api.newshore.es/api/flights/2" );
		}

		public T Get<T>( RestRequest request ) where T : class
		{
			return this.client.Get<T>( request );
		}
	}
}
