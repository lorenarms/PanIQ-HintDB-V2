using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class PuzzlesBase : ComponentBase
	{
		[Parameter]
		public int roomId { get; set; }

		[Inject]
		public IHintService HintService { get; set; }
		public IEnumerable<PuzzleDto> Puzzles { get; set; }

		public string ErrorMessage { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				Puzzles = await HintService.GetPuzzlesByRoomId(roomId);
			}
			catch (System.Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
