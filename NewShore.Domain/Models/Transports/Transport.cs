using System.Text.Json.Serialization;
using NewShore.Domain.Models.Flights;

namespace NewShore.Domain.Models.Transports
{
	public class Transport
	{
		public int Id { get; set; }

		public string FlightCarrier { get; set; }

		public string FlightNumber { get; set; }

		[JsonIgnore]
		public List<Flight> Flights { get; set; }
	}
}
