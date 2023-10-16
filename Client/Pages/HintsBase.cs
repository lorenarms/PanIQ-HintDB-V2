using Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace Client.Pages
{
	public class HintsBase : ComponentBase
	{
		[Inject]
		public IHintService HintService { get; set; }

		public IEnumerable<HintDto> Hints { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Hints = await HintService.GetItems();
		}

	}
}
