using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class HintsBase : ComponentBase
	{
		[Parameter]
		public int PuzzleId { get; set; }
		[Parameter]
		public string Puzzle { get; set; }

		[Inject]
		public IHintService HintService { get; set; }

		public IEnumerable<HintDto> Hints { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Hints = await HintService.GetHints(PuzzleId);
			if (Hints != null)
			{
				var tempHintForPuzzleName = Hints.FirstOrDefault(x => x.PuzzleId == PuzzleId);
				if (tempHintForPuzzleName != null) Puzzle = tempHintForPuzzleName.PuzzleName;
			}
		}

	}
}
