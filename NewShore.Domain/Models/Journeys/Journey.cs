namespace NewShore.Domain.Models.Journeys
{
	using Flights;

	public class Journey
	{
		public Journey( string origin, string destination, decimal price, IEnumerable<Flight> flights )
		{
			this.Origin = origin;
			this.Destination = destination;
			this.Price = price;
			this.Flights = flights;
		}

		public string Origin { get; set; }

		public string Destination { get; set; }

		public decimal Price { get; set; }

		public IEnumerable<Flight> Flights { get; set; }
	}
}
