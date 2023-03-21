using Microsoft.AspNetCore.Mvc;
using NewShore.Application.Services.Journeys;
using NewShore.Domain.Models.Journeys;

namespace NewShore.Api.Controllers
{
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
				return BadRequest( "El valor de origin y destination no pueden ser iguales." );
			}

			return Ok(this.journeyService.Get( journey ));
		}
	}
}