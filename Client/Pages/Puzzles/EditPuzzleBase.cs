using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages.Puzzles
{
	public class EditPuzzleBase : ComponentBase
	{
		[Parameter] public int PuzzleId { get; set; }
		[Parameter] public string PuzzleName { get; set; }

		[Inject] public IPuzzleService PuzzleService { get; set; }

		public PuzzleDto PuzzleToEdit { get; set; } = new PuzzleDto();
		private PuzzleDto Temp { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				var puzzles =  await PuzzleService.GetPuzzles();
				if (puzzles != null)
				{
					PuzzleToEdit = puzzles.SingleOrDefault(p => p.Id == PuzzleId);
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
			//await PuzzleService.AddNewPuzzleToRoom(PuzzleToEdit);
		}

		public void reset()
		{
			PuzzleToEdit = Temp;
		}
	}
}
