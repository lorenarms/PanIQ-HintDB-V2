using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages.Puzzles
{
	public class PuzzlesBase : ComponentBase
	{
		[Parameter]
		public int RoomId { get; set; }

		[Parameter]
		public string RoomName { get; set; }

		[Inject]
		public IPuzzleService PuzzleService { get; set; }
		public IEnumerable<PuzzleDto> Puzzles { get; set; }

		public string ErrorMessage { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				Puzzles = await PuzzleService.GetPuzzlesByRoom(RoomId);
				if (Puzzles != null)
				{
					var tempRoomName = Puzzles.FirstOrDefault(x => x.RoomId == RoomId);
					if (tempRoomName != null)
					{
						RoomName = tempRoomName.RoomName;
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
