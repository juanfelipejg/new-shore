namespace NewShore.Infrastructure.Data
{
	using Microsoft.EntityFrameworkCore;
	using Domain.Models.Journeys;

	public interface INewShoreContext
	{
		DbSet<Journey> Journeys();

		int SaveChanges();
	}
}
