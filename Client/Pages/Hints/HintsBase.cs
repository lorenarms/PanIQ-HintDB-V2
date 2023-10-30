using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class HintsBase : ComponentBase
	{
		[Parameter]
		public int puzzleId { get; set; }
		[Parameter]
		public PuzzleDto puzzle { get; set; }

		[Inject]
		public IHintService HintService { get; set; }

		public IEnumerable<HintDto> Hints { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Hints = await HintService.GetHints(puzzleId);
			/*TODO: add GetPuzzleById method to HintService to retrieve
			the puzzle information for this page (as DTO)
			 */
		}

	}
}
