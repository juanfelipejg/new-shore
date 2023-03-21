namespace NewShore.Api.Controllers
{
	using Application;
	using Application.Services.Journeys;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route( "[controller]" )]
	public class JourneyController: ControllerBase
	{
		private readonly IJourneyService journeyService;

		public JourneyController( IJourneyService journeyService )
		{
			this.journeyService = journeyService;
		}

		[HttpGet]
		public IActionResult Get( [FromQuery] Dtos.Journeys.Journey journey)
		{
			if( journey.Origin == journey.Destination )
			{
				return this.BadRequest( "El valor de origin y destination no pueden ser iguales." );
			}

			try
			{
				return this.Ok( this.journeyService.Get( journey ) );
			}

			catch ( RouteNotFound ex )
			{
				return this.NotFound( new { error = ex.Message } );
			}			
		}
	}
}