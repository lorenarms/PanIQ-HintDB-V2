using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages.Puzzles
{
	public class EditPuzzleBase : ComponentBase
	{
		[Parameter] public int puzzleId { get; set; }
		[Parameter] public string puzzleName { get; set; }

		[Inject] public IHintService HintService { get; set; }

		public PuzzleDto PuzzleToEdit { get; set; } = new PuzzleDto();
		private PuzzleDto _temp { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				var puzzles =  await HintService.GetPuzzles();
				if (puzzles == null)
				{
					PuzzleToEdit = puzzles.SingleOrDefault(p => p.Id == puzzleId);
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
			
		}

		public async Task HandleSubmit()
		{
			await HintService.AddNewPuzzleToRoom(PuzzleToEdit);
		}

		public void reset()
		{
			PuzzleToEdit = _temp;
		}
	}
}
