using NewShore.Domain.Models.Journeys;

namespace NewShore.Application.Services.Journeys
{
	public interface IJourneyService
	{
		Journey Get( Dtos.Journeys.Journey journey );
	}
}
