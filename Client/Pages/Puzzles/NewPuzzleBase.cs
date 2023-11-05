using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models.DTOs;

namespace Client.Pages.Puzzles
{
	public class NewPuzzleBase : ComponentBase
	{
		[Parameter]
		public int RoomId { get; set; }
		[Parameter]
		public string RoomName { get; set; }

		
		[Inject]
		public IPuzzleService PuzzleService { get; set; }
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public PuzzleDto NewPuzzleToAdd { get; set; } = new();

		
		public async Task HandleSubmit()
		{
			NewPuzzleToAdd.RoomId = RoomId;
			await PuzzleService.AddNewPuzzleToRoom(NewPuzzleToAdd, RoomId);
			NavigationManager.NavigateTo($"/puzzles/{RoomId}/{RoomName}");
		}

		public void Reset()
		{
			NewPuzzleToAdd.Name = null;
			NewPuzzleToAdd.Description = null;
			NewPuzzleToAdd.Order = 0;
		}
		
	}
}
