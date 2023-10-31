using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class PuzzlesBase : ComponentBase
	{
		[Parameter]
		public int roomId { get; set; }

		[Parameter]
		public string roomName { get; set; }

		[Inject]
		public IHintService HintService { get; set; }
		public IEnumerable<PuzzleDto> Puzzles { get; set; }

		public string ErrorMessage { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				Puzzles = await HintService.GetPuzzlesByRoomId(roomId);
				if (Puzzles != null)
				{
					var tempRoomName = Puzzles.FirstOrDefault(x => x.RoomId == roomId);
					if (tempRoomName != null)
					{
						roomName = tempRoomName.RoomName;
					}
				}

			}
			catch (System.Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
