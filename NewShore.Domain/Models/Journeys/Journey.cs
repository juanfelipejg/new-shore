namespace NewShore.Domain.Models.Journeys
{
	using Flights;

	public class Journey
	{
		protected ICollection<Flight> flights;

		public Journey( string origin, string destination, decimal price )
		{
			this.Origin = origin;
			this.Destination = destination;
			this.Price = price;
			this.flights = new List<Flight>();
		}

		public int Id { get; set; }

		public string Origin { get; set; }

		public string Destination { get; set; }

		public decimal Price { get; set; }

		public List<Flight> Flights => this.flights.ToList();

		public void AddFlights( IEnumerable<Flight> flights)
		{
			foreach( Flight flight in flights )
			{
				this.flights.Add( flight );
			}
		}
	}
}
