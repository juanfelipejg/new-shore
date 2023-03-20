using NewShore.Domain.Models.Flights;

namespace NewShore.Domain.Serivces.Flights
{
	public interface IFlightsGetter
	{
		List<Flight> Get();
	}
}
