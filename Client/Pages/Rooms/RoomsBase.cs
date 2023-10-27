using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class RoomsBase : ComponentBase
	{
		[Inject]
		public IHintService HintService { get; set; }
		public IEnumerable<RoomDto> Rooms { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Rooms = await HintService.GetRooms();
		}
	}
}
