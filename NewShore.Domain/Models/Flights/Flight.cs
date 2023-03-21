namespace NewShore.Domain.Models.Flights
{
	using System.Text.Json.Serialization;
	using Journeys;
	using Transports;

	public class Flight
	{
		public int Id { get; set; }

		public string Origin { get; set; }

		public string Destination { get; set; }

		public decimal Price { get; set; }

		public Transport Transport { get; set; }

		[JsonIgnore]
		public IEnumerable<Journey> Journeys { get; set; }
	}
}
