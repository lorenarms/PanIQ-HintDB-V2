using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models.DTOs;

namespace Client.Pages.Puzzles
{
	public class NewPuzzleBase : ComponentBase
	{
		[Parameter]
		public int roomId { get; set; }
		[Parameter]
		public string roomName { get; set; }

		
		[Inject]
		public IHintService HintService { get; set; }

		public PuzzleDto NewPuzzleToAdd { get; set; } = new();

		
		public async Task HandleSubmit()
		{
			NewPuzzleToAdd.RoomId = roomId;
			await HintService.AddNewPuzzleToRoom(NewPuzzleToAdd);
			reset();
		}

		public void reset()
		{
			NewPuzzleToAdd.Name = null;
			NewPuzzleToAdd.Description = null;
			NewPuzzleToAdd.Order = 0;
		}
		
	}
}
