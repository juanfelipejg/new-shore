namespace NewShore.Infrastructure.Data
{
	using Microsoft.EntityFrameworkCore;
	using Domain.Models.Journeys;

	public class NewShoreContext: DbContext, INewShoreContext
	{
		public NewShoreContext( DbContextOptions<NewShoreContext> options ) : base( options ) { }	
	
		public DbSet<Journey> Journeys() => this.Set<Journey>();

		public int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}

			catch( DbUpdateException ex )
			{
				throw new Exception( "Ocurrió un error al guardar los cambios en la base de datos.", ex );
			}
		}

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			base.OnModelCreating( modelBuilder );
			modelBuilder.Entity<Journey>();
		}
	}
}
