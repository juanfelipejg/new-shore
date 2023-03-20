using NewShore.Domain.Models.Flights;
using NewShore.Domain.Serivces.Flights;
using NewShore.Infrastructure.Wrapper;
using RestSharp;

namespace NewShore.Infrastructure.Services
{
	public class FlightsGetter: IFlightsGetter
	{
		private IRestClientWrapper restClientWrapper;

		public FlightsGetter( IRestClientWrapper restClientWrapper)
		{
			this.restClientWrapper = restClientWrapper;
		}

		public List<Flight> Get()
		{
			var request = new RestRequest( "/2" );
			return this.restClientWrapper.Get<List<Flight>>( request );
		}
	}
}
