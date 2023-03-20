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
		public Journey Get( [FromQuery] Dtos.Journeys.Journey journey)
		{
			return this.journeyService.Get( journey );
		}
	}
}