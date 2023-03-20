using NewShore.Domain.Models.Flights;
using RestSharp;

namespace NewShore.Infrastructure.Wrapper
{
	public interface IRestClientWrapper
	{
		T Get<T>( RestRequest request ) where T : class;
	}
}
